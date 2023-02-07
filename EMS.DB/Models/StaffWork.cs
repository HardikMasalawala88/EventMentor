using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class StaffWork : BaseEntity
    {
        [Required]
        public string OperatorName { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string EventService { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string SlotTime { get; set; }
        [Required]
        public string Venue { get; set; }

    }
}