using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.EntityFramework;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogComment blogComment = new BlogComment();
        public ActionResult Index()
        {
            //var model = c.Blogs.ToList();
            blogComment.Blogs = c.Blogs.ToList();
            return View(blogComment);
        }
       
        public ActionResult BlogDetails(int id)
        {
            //var blogfind = c.Blogs.Where(x => x.ID == id).ToList();
            blogComment.Blogs = c.Blogs.Where(x => x.ID == id).ToList();
            blogComment.Comments = c.Comments.Where(x => x.BlogId == id).ToList();  

            return View(blogComment);
        }
        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.deger = id; 
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddComment(Comment comment)
        {
           
            c.Comments.Add(comment);
            c.SaveChanges();
            return PartialView("AddComment",comment);
        }
        
    }
}