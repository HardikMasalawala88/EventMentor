using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class CategoryService : BaseEntity
    {
        public String ServiceName{ get; set; }

        public long EventCategoryId { get; set; }

        public EventCategory EventCategory { get; set; }

        public virtual List<Inquiry> Inquiry { get; set; }
    }
}
