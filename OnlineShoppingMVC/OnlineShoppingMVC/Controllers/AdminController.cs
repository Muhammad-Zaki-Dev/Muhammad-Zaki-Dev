using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult LoginIndex()
        {
            return View();
        }
        public ActionResult RegistrationIndex()
        {
            return View();
        }
        public ActionResult AdminRegistration(_Admin admin)
        {
            admin.AdminImage = UploadFile(admin.Image);
            MD_Admin.Save(admin);
            return Json(1,JsonRequestBehavior.AllowGet);
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        public ActionResult LogIn(_Admin admin)
        {
            var data = MD_Admin.GetTable(admin);
            if (data.Count>0)
            {
                Session["AdminID"] = data[0].AdminID;
                Session["AdminImage"] = data[0].AdminImage;
                return RedirectToAction("DashBoard", "Index");
            }
            return Json(1,JsonRequestBehavior.AllowGet);
        }
        public ActionResult AdminProfile()
        {
            _Admin admin = new _Admin();
            admin.AdminID = Convert.ToInt32(Session["AdminID"]);
            var data = MD_Admin.GetTable(admin);
            return View("AdminProfile",data);
        }
        public ActionResult Update(_Admin admin)
        {
            admin.AdminImage = UploadFile(admin.Image);
            MD_Admin.Save(admin);
            return Json(1, JsonRequestBehavior.AllowGet);

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