using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {

            var data = MD_Order.Get(new _Order());
            return View(data);
        }
        public ActionResult GetOrder()
        {
            var data = MD_Order.Get(new _Order());
            return PartialView("_ViewOrder", data);
        }
        public ActionResult CountOrder()
        {
            var lst = MD_Order.CountOrder();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

    }
}