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
    public class EventRepository : IEventRepository
    {
        #region Property
        private IRepository<Event> _repository;
        private AppDbContext _appDbContext;
        #endregion

        #region Constructor
        public EventRepository(IRepository<Event> repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }
        #endregion

        //public List<Event> GetList() => _repository.GetAll();
        public List<Event> GetList() {
            return _appDbContext.Events.Include(x => x.Inquiry).ToList();
        }

        public Event GetById(long id)
        {
            return _repository.GetById(id);
        }

        public void Insert(Event eventModel)
        {
            if (eventModel.Id is 0) 
                _repository.Insert(eventModel);
            //else _repository.Update(eventModel);
        }

        public void Update(Event eventModel)
        {
            _repository.Update(eventModel);
        }

        public void Delete(long id)
        {
            Event events = _appDbContext.Events.FirstOrDefault(c => c.Id.Equals(id));
            _repository.Remove(events);
            _repository.SaveChanges();
        }
    }
}
