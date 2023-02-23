using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class NotificationMessages : BaseEntity
    {
        public string Message { get; set; } = "";
        public string Title { get; set; } = "";
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
