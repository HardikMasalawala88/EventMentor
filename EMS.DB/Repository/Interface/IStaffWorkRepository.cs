using EMS.DB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Repository.Interface
{
    public interface IStaffWorkRepository
    {
        public List<StaffWork> GetStaffWorkList();
        public void Insert(StaffWork StaffWorkModel);
        public void Delete(long id);
    }
}