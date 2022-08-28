using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDAL _commentDAL;
        public CommentManager(ICommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }
        public void CommentAdd(Comment comment)
        {
            _commentDAL.Insert(comment);
        }

        public void CommentDelete(Comment comment)
        {
            _commentDAL.Delete(comment);
        }

        public void CommentUpdate(Comment comment)
        {
            _commentDAL.Update(comment);
        }

        public Comment GetByID(int id)
        {
            return _commentDAL.Get(x => x.CommentID == id);
        }

        public List<Comment> GetList()
        {
            return _commentDAL.List();
        }

        public List<Comment> GetListByID(int id)
        {
            return _commentDAL.List(x => x.CommentID == id);
        }
    }
}
