using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMultiLayerProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager am = new AboutManager(new EFAboutDAL());
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var AboutValue = am.GetList();
            return View(AboutValue);
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var aboutvalue = am.GetByID(id);
            return View(aboutvalue);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            am.AboutUpdate(p);
            return RedirectToAction("Index");
        }
    }
}