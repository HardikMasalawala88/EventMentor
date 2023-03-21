using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.DB.Models
{
    public class CategoryService : BaseEntity
    {
        [Required]
        [RegularExpression(@"^[A-Za-z]{1,10}$", ErrorMessage = "please enter only alphabets.")]
        public String ServiceName{ get; set; }
        public virtual List<Inquiry> Inquiry { get; set; }
    }
}
