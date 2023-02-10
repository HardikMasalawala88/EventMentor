using EMS.DB;
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
    public class PaymentRepository : IPaymentRepository
    {

        #region Property
        private IRepository<Payment> _repository;
        private AppDbContext _appDbContext;
        #endregion

        #region Constructor
        public PaymentRepository(IRepository<Payment> repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }

        public void Delete(long id)
        {
            Payment Payments = _appDbContext.Payments.FirstOrDefault(c => c.Id.Equals(id));
            _repository.Remove(Payments);
            _repository.SaveChanges();
        }
        public void Update(Payment PaymentModel)
        {
            _repository.Update(PaymentModel);
        }
        public Payment GetById(long id)
        {
            return _repository.GetById(id);
        }
     
        public List<Payment> GetPaymentList()
        {
            return _appDbContext.Payments
                    .Include(x => x.Event).ToList();

        }
        //_repository.GetAll();

        public List<Payment> GetPaymentListByEventId(long eventId)
        { 
        return   _appDbContext.Payments
                .Include(x => x.Event).Where(x => x.EventId == eventId).ToList();

        } 
        public void Insert(Payment PaymentModel)
        {
            if (PaymentModel.Id is 0)
                _repository.Insert(PaymentModel);
            else _repository.Update(PaymentModel);
        }

       


        #endregion



    }
}

