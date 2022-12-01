using MyBlogApp2.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogApp2.DAL
{
    public class MyBlogApp2DAL
    {
        MyBlogEntities db = new MyBlogEntities();
        public List<AuthorModel> GetAuthors()
        {
            List<AuthorModel> result = (from a in db.Authors select new AuthorModel
                                        {
                                            AuthorSurname=a.AuthorName,

                                            AuthorName = a.AuthorName,
                                            AuthorID = a.AuthorID,  
                                            IsDeleted=a.IsDeleted
                                        }).Where(x=>x.IsDeleted== false).ToList();
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }

           
        }
        public AuthorModel GetAuthorById(int id)
        {
            var rest = new AuthorModel();
            var result = db.Authors.Where(x => x.IsDeleted == false).FirstOrDefault(x => x.AuthorID == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                rest.AuthorName = result.AuthorName;
                rest.AuthorSurname = result.AuthorSurname;
                rest.AuthorID = result.AuthorID;
                return rest;
            }
        }
        public Author CreateAuthor(Author author)
        {
            
            try
            {
                Author newAuthor = new Author();
                newAuthor.AuthorName = author.AuthorName;
                newAuthor.AuthorSurname = author.AuthorSurname;
                db.Authors.Add(newAuthor);
                //db.savechanges returns int. If it saves 3 data, it returns 3 as int.  
                if (db.SaveChanges()>0)
                {
                    return newAuthor;
                }
                else
                {
                    return null;
                }
                
                
            }
            catch (Exception ex)
            {
                throw (ex);              
            }
            

        }
        public Author UpdateAuthor(Author author, int id)
        {
            var exist = db.Authors.FirstOrDefault(x => x.AuthorID == id);
            exist.AuthorName = author.AuthorName;
            exist.AuthorSurname = author.AuthorSurname;
            db.SaveChanges();
            return author;
        }
        public void DeleteAuthor(int id)
        {
            var exist = db.Authors.FirstOrDefault(x => x.AuthorID == id);
            //var exist2=db.Authors.Find(id) alternatif olarak yazılıyor. 
            exist.IsDeleted = true;
            db.SaveChanges();

        }
        public List<CategoryModel> GetCategories()
        {
            List<CategoryModel> result = (from c in db.Categories
                                          select new CategoryModel
                                          {
                                              CategoryId = c.CategoryID,
                                              CategoryName = c.Name
                                          }).Where(x => x.IsDeleted == false).OrderBy(c => c.CategoryName).ToList();
            return result;
        }
        public Category GetCategoryById(int id)
        {
            var result = db.Categories.Where(x => x.IsDeleted == false).FirstOrDefault(x => x.CategoryID == id);
            return result;
        }
        public Category CreateCategory(Category category)
        {
            Category newCategory = new Category();
            newCategory.Name = category.Name;
            db.Categories.Add(newCategory);
            db.SaveChanges();
            return newCategory;
        }
        public Category UpdateCategory(Category category, int id)
        {
            var exist = db.Categories.FirstOrDefault(x => x.CategoryID == id);
            exist.Name = category.Name;
            db.SaveChanges();
            return category;

        }
        public List<ArticleModel> GetArticles()
        {
            List<ArticleModel> result = (from a in db.Articles
                                         select new ArticleModel
                                         {
                                             articleContent = a.Content,
                                             articleTitel = a.Titel,
                                             articleId = a.ArticleID
                                         }).Where(x => x.IsDeleted == false).OrderBy(c => c.articleTitel).ToList();
            return result;
        }
        public ArticleModel GetArticleById(int id)
        {
            var rest = new ArticleModel();
            var result = db.Articles.Where(x => x.IsDeleted == false).FirstOrDefault(x => x.ArticleID == id);
            rest.articleId = result.ArticleID;
            rest.articleTitel = result.Titel;
            rest.articleContent = result.Content;
            return rest;
        }
        public List<ArticlesToAuthorsModel> GetArticlesToAuthors()
        {
            List<ArticlesToAuthorsModel> result = (from a in db.Articles
                                                   join
                                                   b in db.AuthorsArticles on a.ArticleID
                                                   equals b.ArticleID
                                                   join c in db.Authors
                                                   on b.AuthorID equals c.AuthorID

                                                   select new ArticlesToAuthorsModel
                                                   {
                                                       articleId = a.ArticleID,
                                                       authorId = c.AuthorID,
                                                       articleTitel = a.Titel,
                                                       articleContent = a.Content,
                                                       authorName = c.AuthorName,
                                                       authorSurname = c.AuthorSurname

                                                   }).Where(x => x.IsDeleted == false).ToList();
            return result;
        }
        public List<ArticlesToAuthorsModel> GetArticlesByAuthorId(int id)
        {
            //select * from Authors a inner join AuthorsArticles b on a.AuthorID=b.AuthorID inner join Articles c on b.ArticleID=c.ArticleID
            List<ArticlesToAuthorsModel> result = (from a in db.Authors
                                                   join
                                                   b in db.AuthorsArticles
                                                   on a.AuthorID equals b.AuthorID
                                                   join c in db.Articles
                                                   on b.ArticleID equals c.ArticleID
                                                   where (b.AuthorID == id)
                                                   select new ArticlesToAuthorsModel
                                                   {
                                                       articleContent = c.Content,
                                                       articleId = c.ArticleID,
                                                       articleTitel = c.Titel,
                                                       authorId = a.AuthorID,
                                                       authorName = a.AuthorName,
                                                       authorSurname = a.AuthorSurname,


                                                   }).Where(x => x.IsDeleted == false).OrderBy(x => x.articleTitel).ToList();
            return result;
        }

        //bunların modellerine IsDeleted eklememi istedi neden?
        public List<ArticlesToCategoriesModel> GetArticlesByCategoryId(int id)
        {
            List<ArticlesToCategoriesModel> result = (from a in db.Articles
                                                      join b in db.Categories
                                                      on a.CategoryID equals b.CategoryID
                                                      join c in db.AuthorsArticles
                                                      on a.ArticleID equals c.ArticleID
                                                      join d in db.Authors
                                                      on c.AuthorID equals d.AuthorID
                                                      where (a.CategoryID == id)
                                                      select new ArticlesToCategoriesModel
                                                      {
                                                          categoryId = a.CategoryID,
                                                          articleId = a.ArticleID,
                                                          authorId = d.AuthorID,
                                                          articleContent = a.Content,
                                                          articleTitel = a.Titel,
                                                          authorName = d.AuthorName,
                                                          authorSurname = d.AuthorSurname


                                                      }).Where(x => x.IsDeleted == false).OrderBy(x => x.articleTitel).ToList();
            return result;

        }
        public Article CreateArticle(ArticleModel article)
        {
            Article newArticle = new Article();
            newArticle.Titel = article.Titel;
            newArticle.Status = article.Status;
            newArticle.Content = article.Content;
            newArticle.PublishDate = article.PublishDate;
            newArticle.CategoryID = article.CategoryID;
            db.Articles.Add(newArticle);
            db.SaveChanges();

            foreach (var authorId in article.authorId)
            {
                var newauthorsArticle = new AuthorsArticle();
                newauthorsArticle.ArticleID = newArticle.ArticleID;
                newauthorsArticle.AuthorID = authorId;
                db.AuthorsArticles.Add(newauthorsArticle);
                db.SaveChanges();
            };

            return newArticle;
        }
        public ArticleModel UpdateArticle(ArticleModel article, int id)
        {
            var exist = db.Articles.FirstOrDefault(x => x.ArticleID == id);
            exist.Titel = article.Titel;
            exist.Content = article.Content;
            exist.PublishDate = article.PublishDate;
            exist.Status = article.Status;
            exist.CategoryID = article.CategoryID;
            db.SaveChanges();
            foreach (var authorId in article.authorId)
            {
                var newauthorsArticle = new AuthorsArticle();
                newauthorsArticle.AuthorID = authorId;
                db.SaveChanges();
            };

            return article;

        }
        public List<CommentModel> GetComments()
        {
            List<CommentModel> result = (from a in db.Comments
                                         select new CommentModel
                                         {
                                             CommentID = a.CommentID,
                                             Content = a.Content,
                                             CommenterName = a.CommenterName,
                                             ArticleID = a.ArticleID,
                                             AuthorID = a.AuthorID
                                         }).Where(x => x.IsDeleted == false).OrderBy(c => c.CommentID).ToList();
            return result;
        }
        public List<CommentModel> GetCommentsByAuthorId(int id)
        {
            List<CommentModel> result = (from a in db.Authors
                                         join b in db.Comments
                                         on a.AuthorID equals b.AuthorID
                                         where (a.AuthorID == id)
                                         select new CommentModel
                                         {
                                             CommentID = b.CommentID,
                                             Content = b.Content,
                                             CommenterName = b.CommenterName,
                                             ArticleID = b.ArticleID,
                                             AuthorID = a.AuthorID
                                         }).Where(x => x.IsDeleted == false).OrderBy(x => x.CommentID).ToList();
            return result;
        }
        public List<CommentModel> GetCommentsByArticleId(int id)
        {
            var result = (from a in db.Articles
                          join b in db.Comments
                          on a.ArticleID equals b.ArticleID
                          where (a.ArticleID == id)
                          select new CommentModel
                          {
                              ArticleID = a.ArticleID,
                              AuthorID = b.AuthorID,
                              CommenterName = b.CommenterName,
                              CommentID = b.CommentID,
                              Content = b.Content
                          }).Where(x => x.IsDeleted == false).OrderBy(x => x.ArticleID).ToList();
            return result;
        }

        //Bu sütunlarında yazarlar ile çoka çok ilişkisi olmalı. Çünkü bir bir makalenin birden fazla yazarı olabilir ve bir yorum birden fazla yazar için geçerli olabilir. 

        public Comment CreateComment(Comment comment)
        {
            Comment newComment = new Comment();
            newComment.CommenterName = comment.CommenterName;
            newComment.Content = comment.Content;
            newComment.ArticleID = comment.ArticleID;
            newComment.AuthorID = comment.AuthorID;
            db.Comments.Add(newComment);
            db.SaveChanges();
            return comment;
        }
        public Comment UpdateComment(Comment comment, int id)
        {
            Comment exist = db.Comments.FirstOrDefault(x => x.CommentID == id);
            exist.CommenterName = comment.CommenterName;
            exist.Content = comment.Content;
            exist.ArticleID = comment.ArticleID;
            exist.AuthorID = comment.AuthorID;
            db.SaveChanges();
            return comment;
        }

    }
}



