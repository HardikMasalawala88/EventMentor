using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class Supervisor : BaseEntity
    {
        public long UserId { get; set; }
        public List<User> UserList { get; set; }
    }
}
