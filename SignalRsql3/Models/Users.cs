using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRsql3.Models
{
    public class Users
    {
        /*public int MessageID { get; set; }

        public string Message { get; set; }

        public string EmptyMessage { get; set; }

        public DateTime MessageDate { get; set; }*/


        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public int Salary { get; set; }
    }
}