using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class User : BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Usercontactno { get; set; }
        [Required]
        public string Useremail { get; set; }
        [Required]
        public string Userpassword { get; set; }
        [Required]
        public string Useraddress { get; set; }
        [Required]
        public string Userrole { get; set; }
        [Required]
        public DateTime UserJoiningDate { get; set; } = DateTime.Today;

        public virtual Staff Staffs { get; set; }

    }
}
