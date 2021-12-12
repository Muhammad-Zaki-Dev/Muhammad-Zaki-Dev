using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class AdminBrandController : Controller
    {
        // GET: AdminBrand
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveBrand(_Brand brand)
        {
            brand.BrandImage = UploadFile(brand.Image);
            MD_Brand.Save(brand);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(int BrandID)
        {
            var data = MD_Brand.GetTable(BrandID);
            return PartialView("AddEditBrand", data);
        }
        public ActionResult Delete(int BrandID)
        {
            MD_Brand.Delete(BrandID);
            return Json(1, JsonRequestBehavior.AllowGet);

        }
        public ActionResult _GetTable()
        {
            var data = MD_Brand.GetTable(new _Brand());
            return PartialView("PartialBrand", data);
        }
        public ActionResult GetBrandForm()
        {
            return PartialView("AddEditBrand");

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