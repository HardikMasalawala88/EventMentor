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
    public class StaffWorkRepository : IStaffWorkRepository
    {
        #region Property
        private IRepository<StaffWork> _repository;
        private AppDbContext _appDbContext;
        #endregion

        #region Constructor
        public StaffWorkRepository(IRepository<StaffWork> repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }

        public void Delete(long id)
        {
            StaffWork StaffWorks = _appDbContext.StaffWorks.FirstOrDefault(c => c.Id.Equals(id));
            _repository.Remove(StaffWorks);
            _repository.SaveChanges();
        }
        public void Update(StaffWork StaffWorkModel)
        {
            _repository.Update(StaffWorkModel);
        }

        public List<StaffWork> GetStaffWorkList() => _repository.GetAll();

        public void Insert(StaffWork StaffWorkModel)
        {
            if (StaffWorkModel.Id is 0)
                _repository.Insert(StaffWorkModel);
        }




        #endregion



    }
}