using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace AdminPlatfform.Web.SignalR.hubs
{
    public class ChatLive : Hub
    {
        public void send(string name , string message)
        {
            Clients.All.addViewMessageToPage(name, message);
        }
    }
}