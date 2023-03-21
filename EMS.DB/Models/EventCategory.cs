using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class EventCategory : BaseEntity
    {
        public String CategoryName { get; set; }
        public virtual List<Inquiry> InquiryList { get; set; }
    }
}
