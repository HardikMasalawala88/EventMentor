using EMS.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.unitofwork
{ 
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region property
        private readonly AppDbContext _applicationDbContext;
        private DbSet<T> entities;
        #endregion

        #region Constructor
        public Repository(AppDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
        }
        #endregion
        
        public List<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetById(long id)
        {
            return entities.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            entity.CreatedOn = DateTime.Now;
            entities.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            entity.UpdatedOn = DateTime.Now;
            entities.Update(entity);
            _applicationDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Remove(T entity)
        {

            entities.Remove(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

    }
}
