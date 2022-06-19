using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Chat
{
    public class ChatHub : Hub
    {
        public Task SendMessage1(string destinatario, string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage1", user, message);
        }

        public Task SendMessageToGroup(string sender, string receiver, string message)
        {
            return Clients.Group(receiver).SendAsync("ReceiveMessage", sender, message);
        }
    }
}
