﻿using System;

namespace EMS.DB.Models
{
    public class EventStaffWork: BaseEntity 
    {
        public String Service { get; set; }
        public String Description { get; set; }
        public String Status { get; set; }
        public long StaffId { get; set; }
      
        public Staff Staff { get; set; }
        public long EventId { get; set; }

        public Event Event { get; set; }


    }
}
