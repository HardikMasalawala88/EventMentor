using EMS.DB.Models;
using System;
using System.Collections.Generic;

namespace EMS.DB.Repository.Interface
{
    public interface IEventStaffWorkRepository
    {
        public List<EventStaffWork> GetEventStaffWorkList();
        public List<EventStaffWork> GetListFromWork(DateTime? startDate, DateTime? endDate);
        public List<EventStaffWork> GetListFromEvent(long id);
        public void Insert(EventStaffWork EventStaffWorkModel);
        public void Update(EventStaffWork EventStaffWorkModel);
        public void Delete(long id);
    }
}
