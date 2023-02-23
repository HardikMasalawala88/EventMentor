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
    public class NotificationMessagesRepository : INotificationMessagesRepository
    {
        #region Property
        private IRepository<NotificationMessages> _repository;
        private AppDbContext _appDbContext;
        #endregion

        #region Constructor
        public NotificationMessagesRepository(IRepository<NotificationMessages> repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }
        #endregion
        public List<NotificationMessages> GetMessages()
        {
            return _appDbContext.NotificationMessages.Include(x => x.User).ToList();
        }

        public void Insert(NotificationMessages NotificationMessageModel)
        {
            if (NotificationMessageModel.Id is 0)
                _repository.Insert(NotificationMessageModel);
            //else _repository.Update(eventModel);
        }

        
    }
}
