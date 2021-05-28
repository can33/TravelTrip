using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TravelTripProject.Models.EntityFramework
{
    public class BlogComment
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}