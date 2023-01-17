using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class Event : BaseEntity
    {
        public string EventName { get; set; }
        public string OperatorName { get; set; }
        public string EventVenue { get; set; }
        public string OrganizerName { get; set; }
        public string OrganizerContact { get; set; }
        public string Description { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? ScheduledOn { get; set; }

        public bool IsApproved { get; set; }

        ////Foreign key for Standard
        //public long? InquiryId { get; set; }
        //public Inquiry Inquiry { get; set; }
    }
}
