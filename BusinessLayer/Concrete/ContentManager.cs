using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDAL _contentDAL;

        public ContentManager(IContentDAL contentDAL)
        {
            _contentDAL = contentDAL;
        }

        public void ContentAdd(Content content)
        {
            _contentDAL.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            _contentDAL.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDAL.Update(content);
        }

        public Content GetByHeadingID(int id)
        {
            return _contentDAL.Get(x => x.HeadingID == id);
        }

        public Content GetByID(int id)
        {
            return _contentDAL.Get(x => x.ContentID == id);
        }

        public Content GetByWriterID(int id)
        {
            return _contentDAL.Get(x => x.WriterID == id);
        }

        public List<Content> GetList()
        {
            return _contentDAL.List();
        }

        public List<Content> GetListByHeadingID(int id)
        {
            return _contentDAL.List(x => x.HeadingID == id);
        }

        public List<Content> GetListByID(int id)
        {
            return _contentDAL.List(x => x.ContentID == id);
        }

        public List<Content> GetListByTake(int no)
        {
            return _contentDAL.Takee(no); //DÜZELTİLECEK
        }

        public List<Content> GetListByTakeOBD()
        {
            return (List<Content>)_contentDAL.List().OrderByDescending(x => x.ContentID);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDAL.List(x => x.WriterID == id);
        }
    }
}
