//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBlogApp2.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AuthorsArticle
    {
        public int AuthorID { get; set; }
        public int ArticleID { get; set; }
        public int AuthorsArticlesID { get; set; }
    
        public virtual Article Article { get; set; }
        public virtual Author Author { get; set; }
    }
}
