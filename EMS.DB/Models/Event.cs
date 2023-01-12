﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class Event
    {
        [Key]
        public long EventID { get; set; }
        public string EventName { get; set; }
        public string OperatorName { get; set; }
        public string EventVenue { get; set; }
        public string OrganizerName { get; set; }

        public string OrganizerContact { get; set; }
        public string Description { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? ScheduledOn { get; set; }

        public bool IsApproved { get; set; }
    }
}
