using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class OperatorWork: BaseEntity 
    {
        public String Service { get; set; }
        public String Description { get; set; }
        public String Status { get; set; }

        public Nullable<long> EventId { get; set; }

        public Event Event { get; set; }


    }
}
