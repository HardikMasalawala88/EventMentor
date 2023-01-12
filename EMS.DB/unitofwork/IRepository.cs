using EMS.DB.Models;
using System.Collections.Generic;

namespace EMS.DB.unitofwork
{
    public interface IRepository<T> where T : Event
    {
        List<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}