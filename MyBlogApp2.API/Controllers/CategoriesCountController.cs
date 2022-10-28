using MyBlogApp2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyBlogApp2.API.Controllers
{
    public class CategoriesCountController : ApiController
    {
        MyBlogApp2DAL myBlogApp2DAL = new MyBlogApp2DAL();
        //public IHttpActionResult GetAuthors()
        //{
        //    ArticleCountModel result = myBlogApp2DAL.GetArticlesCounts();
        //    return Ok(result);
        //}
    }
}
