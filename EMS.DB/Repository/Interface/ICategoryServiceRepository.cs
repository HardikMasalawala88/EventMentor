using EMS.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  EMS.DB.Repository.Interface
{
    public interface ICategoryServiceRepository
    {
        public List<CategoryService> GetList();
        public void Insert(CategoryService categoryService);
        public void Update(CategoryService categoryService);
        public void Delete(long id);
    }
}
