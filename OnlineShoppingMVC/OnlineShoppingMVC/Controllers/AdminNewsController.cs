using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class AdminNewsController : Controller
    {
        // GET: AdminNews
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveNews(_News news)
        {
            news.NewsImage = UploadFile(news.Image);
            MD_News.Save(news);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int NewsID)
        {
            MD_News.Delete(NewsID);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(int NewsID)
        {
            var data = MD_News.GetTable(NewsID);
            return PartialView("AddEditNews", data);
        }
        public ActionResult _GetTable()
        {
            var data = MD_News.GetTable(new _News());
            return PartialView("_ViewNews", data);

        }
        public ActionResult GetNewsForm()
        {
            return PartialView("AddEditNews");
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