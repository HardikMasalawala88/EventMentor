using EMS.DB.Models;
using EMS.DB.Repository.Interface;
using EMS.DB.unitofwork;
using System.Collections.Generic;
using System.Linq;

namespace EMS.DB.Repository
{
    public class InquiryRepository : IInquiryRepository
    {

        #region Property
        private IRepository<Inquiry> _repository;
        private AppDbContext _appDbContext;
        #endregion

        #region Constructor
        public InquiryRepository(IRepository<Inquiry> repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }
        #endregion

        public List<Inquiry> GetLists() => _repository.GetAll();

        public void Insert(Inquiry inquiry)
        {
            if (inquiry.Id is 0) _repository.Insert(inquiry);
            else _repository.Update(inquiry);
        }

        public void Delete(long id)
        {
            Inquiry inquiry = _appDbContext.Inquiries.FirstOrDefault(c => c.Id.Equals(id));
            _repository.Remove(inquiry);
            _repository.SaveChanges();
        }
    }
}
