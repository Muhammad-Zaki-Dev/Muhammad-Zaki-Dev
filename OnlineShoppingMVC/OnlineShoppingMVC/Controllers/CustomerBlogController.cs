using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class CustomerBlogController : Controller
    {
        static int? BlogID;
        // GET: CustomerBlog
        public ActionResult Index()
        {
            var lst = MD_Blog.GetTable(new _Blog());
            return View(lst);
        }
        public ActionResult SingleBlog()
        {

            BlogID = Convert.ToInt32(Request.QueryString["BlogID"]);
            return View();
        }
        public ActionResult _SingleBlog(int? ID)
        {
            _Blog blog = new _Blog();
            blog.BlogID = BlogID;
            if (ID!=null)
            {
                blog.BlogID = ID;
            }
           
            var lst = MD_Blog.GetTable(blog);
            return PartialView("_SingleBlog", lst.FirstOrDefault());

        }
        public ActionResult RecentPost()
        {
            return PartialView("_RecentPost");
        }
    }
}