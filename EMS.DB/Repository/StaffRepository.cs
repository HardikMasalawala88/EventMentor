using EMS.DB.Models;
using EMS.DB.Repository.Interface;
using EMS.DB.unitofwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Repository
{
    public class StaffRepository : IStaffRepository
    {
        #region Property
        private IRepository<Staff> _repository;
        private AppDbContext _appDbContext;
        #endregion

        #region Constructor
        public StaffRepository(IRepository<Staff> repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }
        #endregion

        //public List<Staff> GetList() => _repository.GetAll();
        public List<Staff> GetList()
        {
            return _appDbContext.Staffs.Include(x => x.User).ToList();

        }

       
        public void Insert(Staff StaffModel)
        { 
                _repository.Insert(StaffModel);   
        }
        public void Update(Staff StaffModel)
        {
            _repository.Update(StaffModel);
           
        }
    }
}
