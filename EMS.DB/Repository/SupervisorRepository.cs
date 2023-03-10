using EMS.DB.Models;
using EMS.DB.Repository.Interface;
using EMS.DB.unitofwork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Repository
{
    public class SupervisorRepository : BaseRepository,ISupervisorRepository
    {
        #region Property
        private IRepository<Supervisor> _repository;
        private AppDbContext _appDbContext;
        #endregion

        #region Constructor
        public SupervisorRepository(IRepository<Supervisor> repository, AppDbContext appDbContext, IServiceScopeFactory serviceScopeFactor) : base(serviceScopeFactor)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }
        #endregion
        public void Delete(long id)
        {
            //Supervisor Supervisors = _appDbContext.Supervisors.FirstOrDefault(c => c.Id.Equals(id));
            //_repository.Remove(Supervisors);

            using AppDbContext _myContext = base.GetContext();
            //StaffWork StaffWorks = _myContext.StaffWorks.FirstOrDefault(c => c.Id.Equals(id));
            //_myContext.StaffWorks.Remove(StaffWorks);
            _myContext.SaveChanges();
        }

        public List<Supervisor> GetSupervisorList()
        {
            using AppDbContext _myContext = base.GetContext();
            return _myContext.Supervisors.ToList();
        }

        public void Insert(Supervisor SupervisorModel)
        {
            //if (SupervisorModel.Id is 0)
            //    _repository.Insert(SupervisorModel);

            if (SupervisorModel.Id is 0)
            { 
                using AppDbContext _myContext = base.GetContext();
                _myContext.Supervisors.Add(SupervisorModel);
                _myContext.SaveChanges();
            }
        }
    }

}