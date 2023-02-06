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
     public class UserRepository : IUserRepository
    {
        #region Property
        private IRepository<User> _repository;
        private AppDbContext _appDbContext;
        #endregion

        #region Constructor
        public UserRepository(IRepository<User> repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }

        public void Delete(long id)
        {
            User users = _appDbContext.Users.FirstOrDefault(c => c.Id.Equals(id));
            _repository.Remove(users);
            _repository.SaveChanges();
        }
        public void Update(User userModel)
        {
            _repository.Update(userModel);
        }

        public List<User> GetUserList() => _repository.GetAll();

        public void Insert(User userModel)
        {
            if (userModel.Id is 0)
                _repository.Insert(userModel);
        }
        #endregion



    }
}
