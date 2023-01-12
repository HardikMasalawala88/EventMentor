using EMS.DB.Models;
using EMS.DB.unitofwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Service
{
  
    public class EventService : IEventService
    {
        #region Property
        private IRepository<Event> _repository;
        private AppDbContext _appDbContext;
        #endregion

        #region Constructor
        public EventService(IRepository<Event> repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }
        #endregion

        public List<Event> GetEvents() => _repository.GetAll();

        public void InsertEvent(Event customer)
        {
            if (customer.EventID is 0) _repository.Insert(customer);
            else _repository.Update(customer);
        }

        public void DeleteEvent(long id)
        {
            Event events = _appDbContext.EventList.FirstOrDefault(c => c.EventID.Equals(id));
            _repository.Remove(events);
            _repository.SaveChanges();
        }
    }
}
