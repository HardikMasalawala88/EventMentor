using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace EventMentorSystem.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(string sender, string receiver,string msgTitle,string msgBody)
        {
            await Clients.All.SendAsync("ReceiveMessage", sender, receiver, msgTitle, msgBody);
        }
    }
}
