using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMultiLayerProject.Controllers
{
    public class SubController : Controller
    {
        SubManager sm = new SubManager(new EFSubDAL());
        // GET: Sub
        public ActionResult Index()
        {
            var subvalue = sm.GetList();
            return View(subvalue);
        }
    }
}