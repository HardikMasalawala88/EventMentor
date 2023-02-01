using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public class Category : BaseEntity
    {
        public String CategoryName { get; set; }

        public virtual Services Services { get; set; }
    }
}
