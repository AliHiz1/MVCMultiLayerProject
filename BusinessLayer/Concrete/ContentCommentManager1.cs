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
    public class ContentCommentManager1 : IContentCommentService
    {
        IContentDAL _contentDAL;
        public ContentCommentManager1(IContentDAL contentDAL)
        {
            _contentDAL = contentDAL;
        }

        public void ConComAdd(ContentComment contentComment)
        {
            throw new NotImplementedException();
        }

        public void ConComDelete(ContentComment contentComment)
        {
            throw new NotImplementedException();
        }

        public void ConComUpdate(ContentComment contentComment)
        {
            throw new NotImplementedException();
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
            return (List<ContentComment>)_contentDAL.List().OrderByDescending(x => x.ContentID);
        }

        List<ContentComment> IContentCommentService.GetListByContentTake()
        {
            return (List<ContentComment>)_contentDAL.List().Take(3);
        }
    }
}
