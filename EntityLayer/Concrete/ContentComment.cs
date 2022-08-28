using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContentComment
    {
        public IEnumerable<Comment> x1 { get; set; }
        public IEnumerable<Content> x2 { get; set; }
        public IEnumerable<Content> x3 { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
