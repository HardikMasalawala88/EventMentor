using EMS.DB.Models;
using System.Collections.Generic;

namespace  EMS.DB.Repository.Interface
{
    public interface IEventRepository
    {
        public List<Event> GetList();
        public Event GetById(long id);
        public void Insert(Event eventModel);
        public void Update(Event eventModel);
        public void Delete(long id);
        public void SaveChanges();
    }
}