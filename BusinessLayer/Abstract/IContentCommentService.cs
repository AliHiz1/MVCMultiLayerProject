using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentCommentService
    {
        List<ContentComment> GetListByContentOBD();
        List<ContentComment> GetListByContentTake();
        List<ContentComment> GetListByComment();
        ContentComment GetByCommentID(int id);
        ContentComment GetByContentID(int id);
        void ConComAdd(ContentComment contentComment);
        void ConComDelete(ContentComment contentComment);
        void ConComUpdate(ContentComment contentComment);
    }
}
