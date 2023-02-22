using EMS.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Repository.Interface
{
    public interface IUserRepository
    {
        public List<User> GetUserList();
        public List<User> GetStaffList();
        public void Insert(User userModel);
        public void Delete(long id);

    }
}
