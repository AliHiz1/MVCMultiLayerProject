using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMultiLayerProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        CategoryManager cmg = new CategoryManager(new EFCategoryDAL());
        ContentManager cm = new ContentManager(new EFContentDAL());
        AboutManager am = new AboutManager(new EFAboutDAL());
        ContactManager cnm = new ContactManager(new EFContactDAL());
        CommentManager ym = new CommentManager(new EFCommentDAL());
        ContentComment cc = new ContentComment();
        Context c = new Context();
        public ActionResult Index()
        {
            var contentvalue = cm.GetList();
            return View(contentvalue);
        }
        public PartialViewResult Partial1()
        {
            var contentvalue = cm.GetList();
            return PartialView(contentvalue);
        }
        public ActionResult Blog()
        {
            var contentvalue = cm.GetList();
            return View(contentvalue);
        }
        public ActionResult BlogDetay(int id)
        {
            ViewBag.deger = id;
            TempData["idblog"] = id;
            cc.x1 = c.Comments.Where(x => x.ContentID == id).ToList(); 
            cc.x2 = c.Contents.Where(x => x.ContentID == id).ToList(); 
            //var contentvalue = cm.GetByID(id);
            return View(cc);
        }
        [HttpGet]
        public PartialViewResult YorumYap()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult YorumYap(Comment p)
        {
            var a = TempData["idblog"];
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            ym.CommentAdd(p);
            return RedirectToAction ("BlogDetay", new { id = a }); 
        }
        public ActionResult About()
        {
            var aboutvalue = am.GetList();
            return View(aboutvalue);
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View("Contact");
        }
        [HttpPost]
        public ActionResult Contact(Contact p)
        {
            p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cnm.ContactAdd(p);
            return RedirectToAction("Contact");
        }
        public ActionResult Subscribe(string emailaddress)
        {
            if (!string.IsNullOrEmpty(emailaddress))
            {
                int isMail = c.Subs.Where(x => x.SubMail == emailaddress).Select(y => y.SubID).FirstOrDefault();
            
                if(isMail >= 1)
                {
                    ModelState.AddModelError(emailaddress, "Bu mail adresinin aboneliği bulunmaktadır.");
                }
                else
                {
                    Sub mailsub = new Sub();
                    mailsub.SubMail = emailaddress;
                    c.Subs.Add(mailsub);
                    c.SaveChanges();
                }
            }
            string returnvalueee = (string)TempData["returnvaluee"];
            return RedirectToAction(returnvalueee);
        }
    }
}