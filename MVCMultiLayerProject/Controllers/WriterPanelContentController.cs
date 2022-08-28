using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMultiLayerProject.Controllers
{
    [Authorize(Roles = "writer")]
    public class WriterPanelContentController : Controller
    {
        ContentManager cmr = new ContentManager(new EFContentDAL());
        HeadingManager hm = new HeadingManager(new EFHeadingDAL());
        Context c = new Context();
        // GET: WriterPanelContent
        public ActionResult Index(string p)
        {
            p = (string)Session["AdminUserName"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            TempData["writeridid"] = writeridinfo;
            ViewBag.writername = c.Writers.Where(x => x.WriterMail == p).Select(w => w.WriterName).FirstOrDefault();
            ViewBag.writersurname = c.Writers.Where(x => x.WriterMail == p).Select(w => w.WriterSurname).FirstOrDefault();
            ViewBag.writerimage = c.Writers.Where(x => x.WriterMail == p).Select(i => i.WriterImage).FirstOrDefault();
            TempData["writerName"] = ViewBag.writername;
            TempData["writerSurname"] = ViewBag.writersurname;
            TempData["writerImage"] = ViewBag.writerimage;
            var contentvalues = cmr.GetListByWriter(writeridinfo);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult WPContentUpdate(int id)
        {
            var contentvalue = cmr.GetByID(id);
            return View(contentvalue);
        }
        [HttpPost]
        public ActionResult WPContentUpdate(Content p)
        {
            cmr.ContentUpdate(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult WPContentAdd()
        {
            List<SelectListItem> valueheading = (from x in hm.GetList() // DÜZELT
                                                 select new SelectListItem
                                                 {
                                                     Text = x.HeadingName,
                                                     Value = x.HeadingID.ToString()
                                                 }).ToList();
            ViewBag.vlh = valueheading; //DÜZELTİLECEK
            return View();
        }
        [HttpPost]
        public ActionResult WPContentAdd(Content p)
        {
            p.ContentDate = DateTime.Parse(DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            p.ContentStatus = true;
            p.WriterID = (int)TempData["writeridid"];
            Content newcontent = new Content();
            newcontent.ContentImage = p.ContentImage;
            newcontent.ContentValue = p.ContentValue;
            newcontent.HeadingID = p.HeadingID;
            newcontent.ContentStatus = p.ContentStatus;
            newcontent.ContentDate = p.ContentDate;
            newcontent.WriterID = p.WriterID;
            cmr.ContentAdd(newcontent);
            return RedirectToAction("Index");
        }
        public ActionResult WPContentByHeader(int id)
        {
            var wpcontentvalue = cmr.GetListByHeadingID(id);
            return View(wpcontentvalue);
        }
    }
}