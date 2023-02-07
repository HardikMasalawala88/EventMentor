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
    public class EventCategoryRepository : IEventCategoryRepository
    {
        private IRepository<EventCategory> _repository;
        private AppDbContext _appDbContext;

        #region Constructor
        public EventCategoryRepository(IRepository<EventCategory> repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }

        #endregion
    
        public List<EventCategory> GetList() => _repository.GetAll();
        public EventCategory GetById(long id)
        {
            return _repository.GetById(id);
        }
        public void InsertOrUpdate(EventCategory categoryModel)
        {
            if (categoryModel.Id is 0) 
                _repository.Insert(categoryModel);
            else 
                _repository.Update(categoryModel);
        }

        public void Delete(long id)
        {
            EventCategory categorys = _appDbContext.EventCategories.FirstOrDefault(c => c.Id.Equals(id));
            _repository.Remove(categorys);
            _repository.SaveChanges();
        }

       
    }
}
