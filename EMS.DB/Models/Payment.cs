using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class Payment : BaseEntity
    {
        
        [Required]
        public string PaymentMode { get; set; }

        [Required]
        public string TotalAmount { get; set; }

        [Required]
        public string ReceivedAmount { get; set; }

        [Required]
        public string RemainingAmount { get; set; }
        [Required]
        public string Transactionid { get; set; }
        public string Description { get; set; }

        [Required]
        public long EventId { get; set; }

        public Event Event { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

    }
}
