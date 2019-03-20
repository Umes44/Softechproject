using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRChat
{
    public class Home : Hub
    {
        public void Front(string name, string message, string imagename)
        {
            Clients.All.addNewMessageToPage(name, message,imagename);
        }
    }
}