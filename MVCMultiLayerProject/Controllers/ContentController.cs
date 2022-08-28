using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMultiLayerProject.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cmr = new ContentManager(new EFContentDAL());
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cmr.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}