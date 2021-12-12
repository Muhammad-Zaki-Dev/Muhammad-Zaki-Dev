using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(_Category cate)
        {
            cate.CategoryImage = UploadFile(cate.Image);
            if (cate.CategoryID==null)
            {
              
                MD_Category.Save(cate);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                MD_Category.Save(cate);
                return Json(2, JsonRequestBehavior.AllowGet);
            }
           
        }
        public ActionResult Update(int CategoryID)
        {
            var data = MD_Category.GetTable(CategoryID);
            return PartialView("AddEditCategory", data);
        }
        public ActionResult Delete(int CategoryID)
        {
            MD_Category.Delete(CategoryID);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _GetTable()
        {
            var data = MD_Category.GetTable(new _Category());
            return PartialView("PartailCategory", data);
        }
        public ActionResult GetCategoryForm()
        {
            return PartialView("AddEditCategory");
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