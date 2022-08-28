using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string CommentUserName { get; set; }
        public string CommentUserMail { get; set; }
        public string CommentMessage { get; set; }
        public bool CommentStatus { get; set; }
        public DateTime CommentDate { get; set; }
        public int ContentID { get; set; }
        public virtual Content Content { get; set; }
    }
}
