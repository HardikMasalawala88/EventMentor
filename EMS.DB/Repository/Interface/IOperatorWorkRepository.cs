using EMS.DB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Repository.Interface
{
    public interface IOperatorWorkRepository
    {
        public List<OperatorWork> GetOperatorWorkList();
        public void Insert(OperatorWork OperatorWorkModel);
        public void Update(OperatorWork OperatorWorkModel);
        public void Delete(long id);
    }
}
