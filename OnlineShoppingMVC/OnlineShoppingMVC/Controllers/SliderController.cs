using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class SliderController : Controller
    {
        // GET: Slider
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(_Slider slider)
        {
            slider.SliderImage = UploadFile(slider.Image);
            MD_Slider.Save(slider);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update (int SliderID)
        {
            var data = MD_Slider.GetTable(SliderID);
            return PartialView("AddEditSlider", data);
        }
        public ActionResult Delete(int SliderID)
        {
            MD_Slider.Delete(SliderID);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _GetTable()
        {
            var data = MD_Slider.GetTable(new _Slider());
            return PartialView("PartialSlider", data);
        }
        public ActionResult GetSliderForm()
        {
           
            return PartialView("AddEditSlider");
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