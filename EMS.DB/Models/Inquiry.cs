using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class Inquiry
    {
        [Required]
        public string Fullname { get; set; }

        [Required]
        public string MobileNo { get; set; }

        [Required]
        public string AltPhoneNo { get; set; }
        public string Email { get; set; }

        [Required]
        public int NoOfAttendee { get; set; }

        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Landmark { get; set; }
        public string Pincode { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string SlotType { get; set; }
        
        [Required]
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
