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
    [Authorize(Roles = "writer")]
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        Context c = new Context();
        HeadingManager hm = new HeadingManager(new EFHeadingDAL());
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());
        SubManager sm = new SubManager(new EFSubDAL());
        [Authorize(Roles = "writer")]
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult WriterHeadings(string p)
        {
            p = (string)Session["AdminUserName"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            TempData["WPwriterid"] = writeridinfo;
            var values = hm.GetListByWriterPanel(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public  ActionResult WriterNewHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult WriterNewHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.HeadingStatus = true;
            p.WriterID = (int)TempData["WPwriterid"];
            hm.HeadingAdd(p);
            return RedirectToAction("WriterHeadings", new { id = TempData["WPwriterid"] });
        }
        [HttpGet]
        public ActionResult WriterUpdateHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult WriterUpdateHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("WriterHeadings", new { id = p.WriterID });
        }
        public ActionResult WriterDeleteHeading(int id, Heading p)
        {
            var HeadingValue = hm.GetByID(id);
            if (HeadingValue.HeadingStatus == false)
            {
                HeadingValue.HeadingStatus = true;
            }
            else
            {
                HeadingValue.HeadingStatus = false;
            }
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("WriterHeadings", new { id = p.WriterID});
        }
        public ActionResult WriterPanelSub()
        {
            var subvalue = sm.GetList();
            return View(subvalue);
        }
    }
}