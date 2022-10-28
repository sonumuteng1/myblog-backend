using MyBlogApp2.DAL;
using MyBlogApp2.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyBlogApp2.API.Controllers
{
    public class ArticlesController : ApiController
    {
        MyBlogApp2DAL myBlogApp2DAL = new MyBlogApp2DAL();
        [HttpGet]
        public IHttpActionResult GetArticles()
        {
            var result = myBlogApp2DAL.GetArticles();
            return Ok(result);
        }

        //[Route("api/Articles/GetAuthors/id")]
        [HttpGet]
        public IHttpActionResult GetArticle(int id)
        {
            var result = myBlogApp2DAL.GetArticleById(id);
            return Ok(result);
        }

        //[Route("api/Articles/ArticlesToAuthors")]
        [HttpGet]
        public IHttpActionResult GetArticlesToAuthors()
        {
            var result = myBlogApp2DAL.GetArticlesToAuthors();
            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetArticlesByAuthorId(int id)
        {
            var result = myBlogApp2DAL.GetArticlesByAuthorId(id);
            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetArticlesByCategoryId(int id)
        {
            var result = myBlogApp2DAL.GetArticlesByCategoryId(id);
            return Ok(result);
        }
        [HttpPost]
        public IHttpActionResult CreateArticle(ArticleModel article)
        {
            var result = myBlogApp2DAL.CreateArticle(article);
            return Ok(result);
        }
    }
}
