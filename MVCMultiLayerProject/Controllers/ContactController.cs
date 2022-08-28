using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMultiLayerProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cmng = new ContactManager(new EFContactDAL());
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var contactValues = cmng.GetList();
            return View(contactValues);
        }
        public ActionResult ContactDetay(int id)
        {
            var contactValues = cmng.GetByID(id);
            return View(contactValues);
        }
        public ActionResult ContactSil(int id)
        {
            var contactValues = cmng.GetByID(id);
            cmng.ContactDelete(contactValues);
            return RedirectToAction("Index");
        }
    }
}