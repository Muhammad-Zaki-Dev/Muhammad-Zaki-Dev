using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class AdminUnitController : Controller
    {
        // GET: AdminUnit
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(_Unit u)
        {
            MD_Unit.Save(u);
            return Json(1,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(int UnitID)
        {
            var Data = MD_Unit.GetTable(UnitID);
            return Json(Data, JsonRequestBehavior.AllowGet); 
        }
        public ActionResult Delete(int UnitID)
        {
            MD_Unit.Delete(UnitID);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _GetTable()
        {
            var data = MD_Unit.GetTable(new _Unit());
            return PartialView("PartialUnit",data);
        }
        public ActionResult GetUnitForm()
        {
            return PartialView("AddEditUnit");
        }
    }
}