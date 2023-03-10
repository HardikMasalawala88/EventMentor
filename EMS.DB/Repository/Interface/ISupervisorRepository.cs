using EMS.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Repository.Interface
{
    public interface ISupervisorRepository
    {
        public void Insert(Supervisor OperatorModel);
        public void Delete(long id);
        public List<Supervisor> GetSupervisorList();
    }
}
