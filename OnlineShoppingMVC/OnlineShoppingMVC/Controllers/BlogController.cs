using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveBlog(_Blog blog)
        {
            blog.BlogImage = UploadFile(blog.Image);
            blog.IsShowComment = 0;
          
            blog.AdminiD = 1;
            MD_Blog.Save(blog);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int BlogID)
        {
            MD_Blog.Delete(BlogID);
            return Json(1,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(int BlogID)
        {
            var data = MD_Blog.GetTable(BlogID);
            return PartialView("AddEditBlog", data);
        }
        public ActionResult _GetBlog()
        {
            var data=MD_Blog.GetTable(new _Blog());
            return PartialView("PartialBlog", data);


        }
        public ActionResult GetBlogForm()
        {
            return PartialView("AddEditBlog");
        }

        public string UploadFile(HttpPostedFileBase File)
        {
            if (File != null)
            {
                try
                {
                    string Filename = Path.GetFileName(File.FileName);
                    string Ext = Path.GetExtension(Filename);
                    Filename = Guid.NewGuid() + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + Ext;
                    string FolderPath = Path.Combine("~\\UpLoads\\", Filename);
                    File.SaveAs(Server.MapPath(FolderPath));
                    string DomainName = HttpContext.Request.Url.GetLeftPart(UriPartial.Authority);
                    return DomainName + "/UpLoads/" + Filename;
                }
                catch (Exception)
                {

                    return null;
                }

            }
            return null;

        }
    }
}