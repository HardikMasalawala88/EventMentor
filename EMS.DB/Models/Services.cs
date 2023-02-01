using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class Services : BaseEntity
    {
        public String ServiceName{ get; set; }

        public long CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
