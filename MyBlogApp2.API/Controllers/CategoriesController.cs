using MyBlogApp2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyBlogApp2.API.Controllers
{
    public class CategoriesController : ApiController
    {
        MyBlogApp2DAL myBlogApp2DAL = new MyBlogApp2DAL();
        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            List<CategoryModel> result = myBlogApp2DAL.GetCategories();
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetCategoryById(int id)
        {
            var result = myBlogApp2DAL.GetCategoryById(id);
            return Ok(result);
        }
        [HttpPost]
        public IHttpActionResult CreateCategory(Category category)
        {
            var result = myBlogApp2DAL.CreateCategory(category);
            return Ok(result);
        }
        [HttpPut]
        public IHttpActionResult UpdateCategory(Category category, int id)
        {
            var result = myBlogApp2DAL.UpdateCategory(category,id);
            return Ok(result);
        }


        
    }
}
