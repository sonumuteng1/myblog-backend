using MyBlogApp2.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyBlogApp2.DAL;

namespace MyBlogApp2.API.Controllers
{
    public class CommentsController : ApiController
    {
        MyBlogApp2DAL myBlogApp2DAL = new MyBlogApp2DAL();
        [HttpGet] //api/Comment/GetComments
        public IHttpActionResult GetComments()
        {
            var result = myBlogApp2DAL.GetComments();
            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetCommentsByAuthorId(int id)
        {
            var result = myBlogApp2DAL.GetCommentsByAuthorId(id);
            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetCommentsByArticleId(int id)
        {
            var result = myBlogApp2DAL.GetCommentsByArticleId(id);
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult CreateComment(Comment comment)
        {
            var result = myBlogApp2DAL.CreateComment(comment);
            return Ok(comment);

        }
        [HttpPut]
        public IHttpActionResult UpdateComment(Comment comment, int id)
        {
           Comment result=myBlogApp2DAL.UpdateComment(comment, id);
            return Ok(result);
        }
    }
}
