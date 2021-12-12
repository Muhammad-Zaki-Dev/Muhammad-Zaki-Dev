using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult IndexLogin()
        {
            return View();
        }
        public ActionResult IndexRegistration()
        {
            return View();
        }
        
        public ActionResult Login(_User user)
        {
            
                var data = MD_User.GetTable(user);
            if (data.Count>0)
            {
                Session["UserID"] = data[0].UserID;
                Session["UserName"] = data[0].UserName;
                Session["UserImage"] = data[0].UserImage;
                Session["UserContact"] = data[0].UserContact;
                return RedirectToAction("Index","Index");
            }
            return View("IndexLogin", "Customer");
        }
        public ActionResult Registration(_User user)
        {
            user.UserImage = UploadFile(user.Image);

            MD_User.Save(user);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

     public ActionResult Dashboard()
        {
            if (Session["UserID"]!=null)
            {
                _Order order = new _Order();
                order.UserID = Convert.ToInt32(Session["UserID"]);
                var data = MD_Order.Get(order);
                return View(data);
            }
            return RedirectToAction("IndexLogin");
        }
        public ActionResult Profile()
        {
            if (Session["UserID"]!=null)
            {
            
                return View();
            }
            return RedirectToAction("IndexLogin");
        }
        public ActionResult GetProfile()
        {
            _User user = new _User();
            user.UserID = Convert.ToInt32(Session["UserID"]);
            var data = MD_User.GetTable(user);
            return PartialView("_GetProfile",data.FirstOrDefault());
        }
        public ActionResult EditProfile(int UserID)
        {
            var data = MD_User.GetTable(UserID);

            return PartialView("_EditProfile",data);
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