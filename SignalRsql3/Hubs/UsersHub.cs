using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SignalRsql3.Hubs
{
    public class UsersHub : Hub
    {
        private static string conString = ConfigurationManager.ConnectionStrings["Database"].ToString();

        public void Hello()
        {
            Clients.All.hello();
        }

        [HubMethodName("sendUsers")]
        public static void SendUsers()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<UsersHub>();
            context.Clients.All.updateUsers();
        }
    }
}