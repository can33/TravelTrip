using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.EntityFramework;

namespace TravelTripProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context c = new Context();
        public ActionResult Index()
        {
            var model = c.Blogs.ToList();
            return View(model);
        }
        public ActionResult About()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            //Z-A'ya göre sırala ve son 2 yi getir.
            var model = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(model);
        }
        public PartialViewResult Partial2()
        {
            var model = c.Blogs.OrderByDescending(x => x.ID).Take(5).ToList();
            return PartialView(model);
        }
        public PartialViewResult Partial3()
        {
            var model = c.Blogs.Take(3).ToList();
            return PartialView(model);
        }
        public PartialViewResult Partial4()
        {
            var model = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(model);
        }
    }
}