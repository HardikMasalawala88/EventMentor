using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.DB.Models
{
    public class Operator : BaseEntity
    {
        public Operator()
        {
            this.Events = new HashSet<Event>();
        }
        public string UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
