using EMS.DB.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BlazorServerSignalRApp.Server.SignalRHubs
{
    public class ChatHub : Hub
    {
        public async Task EventAddUpdate(Event events)
        {
            await Clients.All.SendAsync("EventAddUpdate", events);
        }
        public async Task CategoruAddUpdate(EventCategory eventCategory)
        {
            await Clients.All.SendAsync("CategoruAddUpdate", eventCategory);
        }
        public async Task ServiceAddUpdate(CategoryService categoryService)
        {
            await Clients.All.SendAsync("ServiceAddUpdate", categoryService);
        }
        public async Task PaymentAddUpdate(Payment Payments)
        {
            await Clients.All.SendAsync("PaymentAddUpdate", Payments);
        }
        public async Task SendMessage(NotificationMessages notificationMessages)
        {
            await Clients.All.SendAsync("SendMessage", notificationMessages);
        }
        
    }
}