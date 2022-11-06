using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogApp2.DAL
{
   public class AuthorModel
    {

        public int AuthorID { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }


            //public string ArticelTitel { get; set; }
            //public string Content { get; set; }


    }
    public class AuthorModel2
    {

        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }


    }
}
