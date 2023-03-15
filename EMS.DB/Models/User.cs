using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string ContactNo { get; set; }
        public string Password { get; set; }
        public string Useraddress { get; set; }
        public string Userrole { get; set; }
        public DateTime UserJoiningDate { get; set; } = DateTime.Today;

        public bool IsActive { get; set; }

        public virtual Staff Staffs { get; set; }
        public virtual Operator Operators { get; set; }
    }
}
