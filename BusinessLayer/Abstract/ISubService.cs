using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISubService
    {
        List<Sub> GetList();
        void SubAdd(Sub sub);
        Sub GetByID(int id);
        void SubDelete(Sub sub);
        void SubUpdate(Sub sub);
    }
}
