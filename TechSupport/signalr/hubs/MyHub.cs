using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TechSupport.signalr.hubs
{
    public class MyHub : Hub
    {
        public static void Send(string name, string message, string role)
        {
            IHubContext hc = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            hc.Clients.All.addNewMessage(name, message, role);
        }
    }
}