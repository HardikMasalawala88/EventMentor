using System.ComponentModel.DataAnnotations;

namespace EMS.DB.Models
{
    public class Supervisor : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
