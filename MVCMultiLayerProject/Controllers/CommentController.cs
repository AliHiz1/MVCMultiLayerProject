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
    public class CommentController : Controller
    {
        CommentManager cc = new CommentManager(new EFCommentDAL());
        Context c = new Context();
        // GET: Comment
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var commentvalue = cc.GetList();
            return View(commentvalue);
        }
        [HttpGet]
        public ActionResult UpdateComment(int id) 
        {
            var commentvalue = cc.GetByID(id);
            return View(commentvalue);
        }
        [HttpPost]
        public ActionResult UpdateComment(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cc.CommentUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult ChangeCommentStatus(int id)
        {
            var commentvalue = cc.GetByID(id);
            if (commentvalue.CommentStatus == true)
            {
                commentvalue.CommentStatus = false;
            }
            else
            {
                commentvalue.CommentStatus = true;
            }
            cc.CommentUpdate(commentvalue);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteComment(int id)
        {
            var commentvalue = cc.GetByID(id);
            cc.CommentDelete(commentvalue);
            return RedirectToAction("Index");
        }
    }
}