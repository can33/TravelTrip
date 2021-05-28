using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.EntityFramework;

namespace TravelTripProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {       
        Context c = new Context();
        // GET: Admin
        public ActionResult Index()
        {
            var model = c.Blogs.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBlog(Blog blog)
        {
            c.Blogs.Add(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBlog(int id)
        {
            var deleteValue = c.Blogs.Find(id);
            if (deleteValue == null)
            {
                return HttpNotFound();
            }
            else
                c.Blogs.Remove(deleteValue);
            c.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult GetBlog(int id)
        {       
            var updateValue = c.Blogs.Find(id);
            return View("GetBlog", updateValue);
        }
        public ActionResult UpdateBlog(Blog blog)
        {
            var updateValue = c.Blogs.Find(blog.ID);
            updateValue.Description = blog.Description;
            updateValue.Heading = blog.Heading;
            updateValue.BlogImage = blog.BlogImage;
            updateValue.Date = blog.Date;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetComment()
        {
            var commentValue = c.Comments.ToList();
            return View(commentValue);
        }
        public ActionResult DeleteComment(int id)
        {
            var deleteValue = c.Comments.Find(id);
            c.Comments.Remove(deleteValue);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCommentAdmin(int id)
        {
            var valueAdmin = c.Comments.Find(id);            
            return View("GetCommentAdmin", valueAdmin);
        }
        public ActionResult UpdateCommentAdmin(Comment comment)
        {
            var valueAdmin = c.Comments.Find(comment.ID);
            valueAdmin.Mail = comment.Mail;
            valueAdmin.YComment = comment.YComment;
            valueAdmin.UserName = comment.UserName;
            c.SaveChanges();
            return RedirectToAction("GetComment");
        }
    }
}