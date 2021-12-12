using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class AdminColorController : Controller
    {
        // GET: AdminColor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(_Color c)
        {
            if (c.ColorID!=null)
            {
                MD_Color.Save(c);
                return Json(2, JsonRequestBehavior.AllowGet);
            }
            MD_Color.Save(c);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(int ColorID)
        {
            var data = MD_Color.GetTable(ColorID);
            return PartialView("AddEditColor",data);
        }
        public ActionResult Delete(int ColorID)
        {
            MD_Color.Delete(ColorID);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _GetTable()
        {
            var data=MD_Color.GetTable(new _Color());
            return PartialView("_PartialColor", data);
        }
        public ActionResult GetFormColor()
        {
            return PartialView("AddEditColor");
        }
    }
}