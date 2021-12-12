using OnlineShoppingMVC.BasePage;
using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class WishListController : Controller
    {
        // GET: WishList
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveProduct(int ProductID)
        {
            if (Convert.ToInt32(Session["UserID"]) == 0)
            {
                return Json(2, JsonRequestBehavior.AllowGet);
            }
            _WishList wish = new _WishList();
            wish.ProductID = ProductID;
            var data = MD_WishList.GetTable(wish);


            if (data.Count > 0)
            {
                return Json(3, JsonRequestBehavior.AllowGet);
            }
            else
            {
                wish.UserID = Convert.ToInt32(Session["UserID"]);
                MD_WishList.Save(wish);
            }

            return Json(1, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetWishList()
        {
            _WishList wish = new _WishList();
            wish.UserID = Convert.ToInt32(Session["UserID"]);
            var data = MD_WishList.GetTable(wish);
            return PartialView("ViewWishList", data);
        }
    }
}