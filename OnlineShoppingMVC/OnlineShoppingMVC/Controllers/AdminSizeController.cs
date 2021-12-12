using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class AdminSizeController : Controller
    {
        // GET: AdminSize
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetFormSize()
        {
            return PartialView("AddEditSize");
        }
        public ActionResult Save(_Size s)
        {
            MD_Size.Save(s);
            return Json(1,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int SizeID)
        {
            var data = MD_Size.GetTable(SizeID);
            return PartialView("PartialSize", data);
        }
        public ActionResult Delete(int SizeID)
        {
            MD_Size.Delete(SizeID);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _GetTable()
        {
            var data = MD_Size.GetTable(new _Size());
            return PartialView("PartialSize", data);
        }
    }
}