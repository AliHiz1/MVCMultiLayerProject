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
    class ContentCommentManager2 : IContentCommentService
    {
        IContentCommentDAL _commentDAL;
        public ContentCommentManager2(IContentCommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }

        public void ConComAdd(ContentComment contentComment)
        {
            _commentDAL.Insert(contentComment);
        }

        public void ConComDelete(ContentComment contentComment)
        {
            _commentDAL.Delete(contentComment);
        }

        public void ConComUpdate(ContentComment contentComment)
        {
            _commentDAL.Update(contentComment);
        }

        ContentComment IContentCommentService.GetByCommentID(int id)
        {
            throw new NotImplementedException();
        }

        ContentComment IContentCommentService.GetByContentID(int id)
        {
            throw new NotImplementedException();
        }

        List<ContentComment> IContentCommentService.GetListByComment()
        {
            throw new NotImplementedException();
        }

        List<ContentComment> IContentCommentService.GetListByContentOBD()
        {
            throw new NotImplementedException();
        }

        List<ContentComment> IContentCommentService.GetListByContentTake()
        {
            throw new NotImplementedException();
        }
    }
}
