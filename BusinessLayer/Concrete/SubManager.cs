using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubManager : ISubService
    {
        ISubDAL _subDAL;
        public SubManager(ISubDAL subDAL)
        {
            _subDAL = subDAL;
        }
        public Sub GetByID(int id)
        {
            return _subDAL.Get(x => x.SubID == id);
        }

        public List<Sub> GetList()
        {
            return _subDAL.List();
        }

        public void SubAdd(Sub sub)
        {
            _subDAL.Insert(sub);
        }

        public void SubDelete(Sub sub)
        {
            _subDAL.Delete(sub);
        }

        public void SubUpdate(Sub sub)
        {
            _subDAL.Update(sub);
        }
    }
}
