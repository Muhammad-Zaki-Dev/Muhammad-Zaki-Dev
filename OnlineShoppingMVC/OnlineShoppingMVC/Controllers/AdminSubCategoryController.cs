using OnlineShoppingMVC.Models;
using OnlineShoppingMVC.Models.Custom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class AdminSubCategoryController : Controller
    {
        // GET: AdminSubCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetFormSubCategory()
        {
            _SubCategory sub = new _SubCategory();
            sub.ddlCategory = DropDowns.ddlCategory(null);


            return PartialView("AddEditSubCategory",sub);
        }
        public ActionResult Save(_SubCategory s)
        {
            s.SubCategoryImage = UploadFile(s.Image);
            if (s.SubCategoryID!=null)
            {
               

                MD_SubCategory.save(s);
                return Json(2, JsonRequestBehavior.AllowGet);
            }
            
            
              
           
            MD_SubCategory.save(s);
            return Json(1, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Update(int SubCategoryID)
        { 
            
             _SubCategory data = MD_SubCategory.GetTable(SubCategoryID);
            
            return PartialView("AddEditSubCategory", data);
        }
        public ActionResult Delete(int SubCategoryID)
        {
            MD_SubCategory.Delete(SubCategoryID);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _GetTable()
        {
            var data = MD_SubCategory.GetTable(new _SubCategory());
            return PartialView("PartialSubCategory", data);
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