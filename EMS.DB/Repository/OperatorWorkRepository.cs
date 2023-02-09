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
    public class OperatorWorkRepository : IOperatorWorkRepository
    { 
        #region Property
        private IRepository<OperatorWork> _repository;
        private AppDbContext _appDbContext;
        #endregion

        #region Constructor
        public OperatorWorkRepository(IRepository<OperatorWork> repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }

        public void Delete(long id)
        {
            OperatorWork OperatorWorks = _appDbContext.OperatorWorks.FirstOrDefault(c => c.Id.Equals(id));
            _repository.Remove(OperatorWorks);
            _repository.SaveChanges();
        }
        public void Update(OperatorWork OperatorWorkModel)
        {
            _repository.Update(OperatorWorkModel);
        }

        //public List<OperatorWork> GetOperatorWorkList() => _repository.GetAll();
        public List<OperatorWork> GetOperatorWorkList()
        {
            
            return _appDbContext.OperatorWorks.Include(x => x.Event).ToList();

        }
        public void Insert(OperatorWork OperatorWorkModel)
        {
            if (OperatorWorkModel.Id is 0)
                _repository.Insert(OperatorWorkModel);
            else _repository.Update(OperatorWorkModel);
        }

        #endregion
    }
}