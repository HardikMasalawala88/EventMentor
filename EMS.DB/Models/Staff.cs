using System.ComponentModel.DataAnnotations;

namespace EMS.DB.Models
{
    public class Staff : BaseEntity
    {
        [Required]
        public long StaffService { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
