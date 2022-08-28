using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMultiLayerProject.Controllers
{
    public class Base1Controller : Controller
    {
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }
    }
}