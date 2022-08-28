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
    public class AdminManager : IAdminService
    {
        IAdminDAL _adminDAL;

        public AdminManager(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public Admin GetAdmin(string AUserName, string APassword)
        {
            return _adminDAL.Get(x => x.AdminUserName == AUserName && x.AdminPassword == APassword);
        }
    }
}
