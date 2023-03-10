using EMS.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Repository.Interface
{
   public interface IOperatorRepository
    {
        public void Insert(Operator OperatorModel);
        public void Delete(long id);
    }
}
