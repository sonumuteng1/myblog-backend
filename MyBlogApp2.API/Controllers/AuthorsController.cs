using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyBlogApp2.DAL;

/*
 byid de sonuç yoksa badrequest mi yoksa notfound mu olmalı
Controllerda ihttpactionresult kullanıyorum ama dal kısmında ne kullanmalıyım. 
ihttpactionresult ile kendi yazdığım message döndürebiliyor muyum?
dal kısmında post için id ayrı mı gönderilmeli yoksa nesneden mi alınmalı
Create Author kısmındaki dönüş tipi nasıl? Başka türlü created dönemiyorum. 

 */

namespace MyBlogApp2.API.Controllers
{
    public class AuthorsController : ApiController
    {
        MyBlogApp2DAL myBlogApp2DAL = new MyBlogApp2DAL();

        [HttpGet]
        public IHttpActionResult GetAuthors()
        {
            var result = myBlogApp2DAL.GetAuthors();
            if (result==null)
            {
                return NotFound();
            }
            
            return Ok(result);
           
        }
        [HttpGet]
        public IHttpActionResult GetAuthor(int id)
        {

            var result = myBlogApp2DAL.GetAuthorById(id);
            if (result==null)
            {
                return BadRequest();
               // return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public IHttpActionResult CreateAuthor(Author newAuthor)
        {
            var result = myBlogApp2DAL.CreateAuthor(newAuthor);
            return Content(HttpStatusCode.Created, result);
            
        }
        [HttpPut]
        public IHttpActionResult UpdateAutor(Author author,int id)
        {
            var result = myBlogApp2DAL.UpdateAuthor(author, id);
            return Ok(result);
            

        }
        [HttpDelete]
        public IHttpActionResult DeleteAuthor(int id)
        {
            myBlogApp2DAL.DeleteAuthor(id);
            return Ok();
        }
    }
}
