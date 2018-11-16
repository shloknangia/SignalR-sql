using SignalRsql3.Hubs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SignalRsql3.Models
{
    public class UsersRepository
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        public IEnumerable<Users> GetAllUsers()
        {
            var users = new List<Users>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT [ID],[FirstName],[LastName],[Gender],[Salary]
               FROM [dbo].[NewEmployees]", connection))
                {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        users.Add(item: new Users { ID = (int)reader["ID"], FirstName = (string)reader["FirstName"], LastName = reader["LastName"] != DBNull.Value ? (string)reader["LastName"] : "", Gender = (string)reader["Gender"], Salary = (int)reader["Salary"] });
                    }
                }

            }
            return users;


        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                UsersHub.SendUsers();
            }
        }
    }
}