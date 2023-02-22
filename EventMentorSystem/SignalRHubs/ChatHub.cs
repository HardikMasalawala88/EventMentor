using EMS.DB.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BlazorServerSignalRApp.Server.SignalRHubs
{
    public class ChatHub : Hub
    {
        public async Task ServiceAddUpdate(EventCategory eventCategory)
        {
            await Clients.All.SendAsync("ServiceAddUpdate", eventCategory);
        }
    }
}