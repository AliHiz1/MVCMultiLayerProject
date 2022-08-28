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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());
        HeadingManager hm = new HeadingManager(new EFHeadingDAL());
        WriterManager wm = new WriterManager(new EFWriterDAL());
        // GET: AdminCategory
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {

            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }

            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult ChangeCategoryStatus(int id)
        {
            var categoryvalue = cm.GetByID(id);
            if(categoryvalue.CategoryStatus == false)
            {
                categoryvalue.CategoryStatus = true;
            }
            else
            {
                categoryvalue.CategoryStatus = false;
            }
            cm.CategoryUpdate(categoryvalue);
            return RedirectToAction("Index");
        }
    }
}