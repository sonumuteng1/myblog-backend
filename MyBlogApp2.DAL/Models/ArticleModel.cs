using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogApp2.DAL.Models
{
   public class ArticleModel
    {
        public int articleId { get; set; }
        public string articleTitel { get; set; }
        public string articleContent { get; set; }
        public List<int> authorId { get; set; }
        
        public int ArticleID { get; set; }
        public string Titel { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
        public int CategoryID { get; set; }
    }

    public class ArticlesToAuthorsModel
    {
        public int authorId { get; set; }
        public int articleId { get; set; }
        public string articleTitel { get; set; }
        public string articleContent { get; set; }
        public string authorName  { get; set; }
        public string  authorSurname { get; set; }
    }
    
    public class ArticlesToCategoriesModel
    {
        
        public int categoryId { get; set; }
        public int articleId { get; set; }
        public int authorId { get; set; }
        public string articleTitel { get; set; }
        public string articleContent { get; set; }
        public string authorName { get; set; }
        public string authorSurname { get; set; }

    }
}
