using EMS.DB.Models;
using System.Collections.Generic;

namespace EMS.DB.Service
{
    public interface IEventService
    {
        public List<Event> GetEvents();
        public void InsertEvent(Event customer);
        public void DeleteEvent(long id);
        //public void InsertCustomer(Event customer);
    }
}