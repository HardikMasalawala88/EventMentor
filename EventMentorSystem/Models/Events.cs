using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventMentorSystem.Models
{
    public class Events
    {
            [Key]
            public long EventID { get; set; }
            public string EventName { get; set; }
            public string Operator { get; set; }
            public string EventVenue { get; set; }
            public string OrganizorName { get; set; } 
            public string OrganizorNo { get; set; } 
    }
}
