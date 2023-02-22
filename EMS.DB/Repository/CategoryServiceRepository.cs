using EMS.DB.Models;
using  EMS.DB.Repository.Interface;
using EMS.DB.unitofwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Repository
{
    public class CategoryServiceRepository : ICategoryServiceRepository
    {
        private IRepository<CategoryService> _repository;
        private AppDbContext _appDbContext;
        public CategoryServiceRepository(IRepository<CategoryService> repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }

        public List<CategoryService> GetList() => _repository.GetAll();

        public void Insert(CategoryService categoryService)
        {
            _repository.Insert(categoryService);
        }
        public void Delete(long id)
        {
            CategoryService services = _appDbContext.CategoryServices.FirstOrDefault(c => c.Id.Equals(id));
            _repository.Remove(services);
            _repository.SaveChanges();
        }

        public void Update(CategoryService categoryService)
        {
            _repository.Update(categoryService);
        }
    }
}
