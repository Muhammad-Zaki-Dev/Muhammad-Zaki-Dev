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
    public class AdminProductController : Controller
    {
        // GET: AdminProduct
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetSubCategory(int categoryId)
        {
            _SubCategory sub = new _SubCategory();
            sub.CategoryID = categoryId;
            List<_SubCategory> lst = MD_SubCategory.GetTable(sub);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save(_Product p,List<string> SizeID,List<string> ColorID)
        {
            p.ProductImage = UploadFile(p.Image);
            if (p.ProductID==null)
            {
               
                int ProductID=MD_Product.Save(p);
                _ProductSize size = new _ProductSize();
                foreach (var item in SizeID)
                {
                    size.ProductID = ProductID;
                    size.SizeID =Convert.ToInt32(item);
                    MD_ProductSize.Save(size);
                }
                _ProductColor color = new _ProductColor();
                foreach (var item in ColorID)
                {
                    color.ProductID = ProductID;
                    color.ColorID = Convert.ToInt32(item);
                    MD_ProductColor.Save(color);
                }
                _ProductUnit unit = new _ProductUnit();
                //foreach (var item in UnitID)
                //{
                   
                //    unit.ProductID = ProductID;
                //    unit.UnitID = Convert.ToInt32(item);
                //    MD_ProductUnit.Save(unit);
                //}
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
            
                MD_Product.Save(p);
                return Json(2, JsonRequestBehavior.AllowGet);
            }
           
        }
        public ActionResult Update(int ProductID)
        {
            var data = MD_Product.GetTable(ProductID);
            data.ddlCategory = DropDowns.ddlCategory(data.CategoryID);
            data.ddlColor = DropDowns.ddlColor(data.ColorID);
            data.ddlSize = DropDowns.ddlSize(data.SizeID);
            data.ddlUnit = DropDowns.ddlUnit(data.UnitID);

            return PartialView("AddEditProduct",data);
        }
        
        public ActionResult Delete(int ProductID)
        {
            MD_Product.Delete(ProductID);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProductForm()
        {
            //_Product product = new _Product();
            //product.ddlCategory = DropDowns.ddlCategory(null);
            //product.ddlUnit = DropDowns.ddlUnit(null);
            //product.ddlColor = DropDowns.ddlColor(null);
            //product.ddlSize = DropDowns.ddlSize(null);
            
            return PartialView("AddEditProduct");
        }
        public ActionResult GetTable()
        {
            var data = MD_Product.GetTable(new _Product());
            return PartialView("PartialProduct", data);
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