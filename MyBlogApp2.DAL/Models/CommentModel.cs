using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogApp2.DAL.Models
{
   public class CommentModel
    {
        public int CommentID { get; set; }
        public string Content { get; set; }
        public string CommenterName { get; set; }
        public int ArticleID { get; set; }
        public int AuthorID { get; set; }

    }
}
