using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogApp2.DAL
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public class ArticleCountModel{
       public string CategoryName { get; set; }
        public int ArticleCount { get; set; } 
    }

}
