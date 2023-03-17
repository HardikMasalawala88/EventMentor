using EMS.DB.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventMentorSystem.Data
{
    public class GlobalParameter
    {
        public HubConnection hubConnection;
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public User LoggedInUser { get; set; }

        /// <summary>
        /// Event that is invoked asynchronously when ticket created from tab.
        /// </summary>
#pragma warning disable S3264 // Events should be invoked
        public event Func<Exception, Task> ErrorTriggerEvent;
#pragma warning restore S3264 // Events should be invoked
        public bool IsUserLoggedIn() {
            if (LoggedInUser is not null && !string.IsNullOrEmpty(LoggedInUser.Email))
                return true;

            return false;
        }

        public async Task ShowErrorMessages(Exception exception)
        {
            await ErrorTriggerEvent.Invoke(exception);
        }
    }
}
