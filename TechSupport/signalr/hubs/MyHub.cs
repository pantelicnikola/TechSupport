using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TechSupport.signalr.hubs
{
    public class MyHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.add(name, message);
        }
    }
}