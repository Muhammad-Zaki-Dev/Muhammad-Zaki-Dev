using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class MainBannerController : Controller
    {
        // GET: MainBanner
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(_MainBanner banner)
        {
            banner.BannerImage = UploadFile(banner.Image);
            MD_MainBanner.SaveBanner(banner);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(int BannerID)
        {
            var data = MD_MainBanner.GetTable(BannerID);
            return PartialView("AddEditBanner",data);
        }
        public ActionResult Delete(int BannerID)
        {
            var data = MD_MainBanner.GetTable(BannerID);
            string path = Server.MapPath(data.BannerImage);
            FileInfo file = new FileInfo(path);
            if (file.Exists)//check file exsit or not  
            {
                file.Delete();
               
            }
            MD_MainBanner.Delete(BannerID);

            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetBannerForm()
        {
            return PartialView("AddEditBanner");
        }
        public ActionResult _GetTable()
        {
            var data = MD_MainBanner.GetTable(new _MainBanner());
            return PartialView("_ViewBanner", data);
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