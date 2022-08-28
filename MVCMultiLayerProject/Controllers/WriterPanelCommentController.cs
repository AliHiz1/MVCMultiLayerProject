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
    public class WriterPanelCommentController : Controller
    {
        CommentManager cc = new CommentManager(new EFCommentDAL());
        // GET: WriterPanelComment
        [Authorize(Roles = "writer")]
        public ActionResult Index()
        {
            var commentvalue = cc.GetList();
            return View(commentvalue);
        }
        [HttpGet]
        public ActionResult WPUpdateComment(int id)
        {
            var commentvalue = cc.GetByID(id);
            return View(commentvalue);
        }
        [HttpPost]
        public ActionResult WPUpdateComment(Comment p)
        {
            cc.CommentUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult WPChangeCommentStatus(int id)
        {
            var commentvalue = cc.GetByID(id);
            if(commentvalue.CommentStatus == true)
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
    }
}