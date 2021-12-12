using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingMVC.Models;

namespace OnlineShoppingMVC.Controllers
{
    public class AdminPaymentController : Controller
    {
        // GET: AdminPayment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SavePayment(_PaymentMethod payment)
        {
            MD_PaymentMethod.Save(payment);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(int MethodID)
        { var data = MD_PaymentMethod.GetTable(MethodID);
            return PartialView("AddEditMethod", data);

        }
        public ActionResult Delete(int MethodID)
        {
            MD_PaymentMethod.Delete(MethodID);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _GetTable()
        {
            return PartialView("PartialMethod", MD_PaymentMethod.GetTable(new _PaymentMethod()));
        }
        public ActionResult GetMethodForm()
        {
            return PartialView("AddEditMethod");
        }


    }
}