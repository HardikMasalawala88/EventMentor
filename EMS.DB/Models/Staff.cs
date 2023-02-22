using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class Staff : BaseEntity
    {
        [Required]
        public long StaffService { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
