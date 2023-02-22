using EMS.DB.Models;
using System.Collections.Generic;

namespace EMS.DB.Repository.Interface
{
    public interface IStaffRepository
    {
        public List<Staff> GetList();
        public void Insert(Staff eventModel);
        public void Update(Staff eventModel);
    }
}