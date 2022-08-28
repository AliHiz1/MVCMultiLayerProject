using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMultiLayerProject.Controllers
{
    public class WriterPanelContactController : Controller
    {
        // GET: WriterPanelContact
        ContactManager cmng = new ContactManager(new EFContactDAL());
        [Authorize(Roles = "writer")]
        public ActionResult Index()
        {
            var contactValues = cmng.GetList();
            return View(contactValues);
        }
        public ActionResult WriterPanelContactDetay(int id)
        {
            var contactValues = cmng.GetByID(id);
            return View(contactValues);
        }
        public ActionResult WriterPanelContactSil(int id)
        {
            var contactValues = cmng.GetByID(id);
            cmng.ContactDelete(contactValues);
            return RedirectToAction("Index");
        }
    }
}