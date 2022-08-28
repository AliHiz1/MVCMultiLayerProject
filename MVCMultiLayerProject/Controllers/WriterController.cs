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
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterDAL());
        HeadingManager hm = new HeadingManager(new EFHeadingDAL());
        WriterValidator writerValidator = new WriterValidator();
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var WriterValues = wm.GetList();
            return View(WriterValues);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteWriter(int id)
        {
            var writerValue = wm.GetByID(id);
            wm.WriterDelete(writerValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var writerValue = wm.GetByID(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult UpdateWriter(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (ModelState.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult WritersContents(int id)
        {
            var headingvalue = hm.GetListByWriter(id);
            return View(headingvalue);
        }
        public ActionResult DeleteHeadingByWriter(int id)
        {
            var headingvalue = hm.GetByID(id);
            if (headingvalue.HeadingStatus == false)
            {
                headingvalue.HeadingStatus = true;
            }
            else
            {
                headingvalue.HeadingStatus = false;
            }
            hm.HeadingDelete(headingvalue);
            return RedirectToAction("WritersContents", new { id = headingvalue.WriterID });
        }
    }
}