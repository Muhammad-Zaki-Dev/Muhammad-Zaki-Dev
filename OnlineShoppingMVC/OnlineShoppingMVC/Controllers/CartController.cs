using OnlineShoppingMVC.DAL;
using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            
            return View();
        }
                
        public ActionResult UpdateCart(int CartID,int Qty)
        {
            var data = MD_Cart.GetTable(CartID);
            data.Qty = Qty;
            data.TotalPrice = data.UnitPrice * data.Qty;
            MD_Cart.Save(data);
            return Json(1, JsonRequestBehavior.AllowGet);

        }
        public ActionResult LoadCart()
        {
            _Cart cart = new _Cart();
            cart.UserID = Convert.ToInt32(Session["UserID"]);
            var data = MD_Cart.GetTable(cart);
            return PartialView("_EditCart", data);
        }
        public ActionResult SaveProduct(int Qty,int UnitPrice,int ColorItem, int SizeItem,int ProductID)
        {

            _Cart cart = new _Cart();
           
            cart.UserID = Convert.ToInt32(Session["UserID"]);
            var data = MD_Cart.GetTable(cart);
            if (data.Count == 0)
            {
                cart.ProductID = ProductID;
                cart.Qty =  Qty;
                cart.UnitPrice = UnitPrice;
                cart.TotalPrice = UnitPrice * cart.Qty;
                cart.ColorID = Convert.ToInt32(ColorItem);
                cart.SizeID = Convert.ToInt32(SizeItem);
                MD_Cart.Save(cart);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
           

            }

            return Json(2, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCartList()
        {
            _Cart cart = new _Cart();
            cart.UserID = Convert.ToInt32(Session["UserID"]);
            var data = MD_Cart.GetTable(cart);
            return PartialView("_ViewCart", data);
        }
        public ActionResult DeleteItem(int CartID)
        {
            MD_Cart.Delete(CartID);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

    }
}