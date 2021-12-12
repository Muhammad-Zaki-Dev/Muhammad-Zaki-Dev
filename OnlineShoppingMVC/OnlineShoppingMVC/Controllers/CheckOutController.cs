using OnlineShoppingMVC.BasePage;
using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        public ActionResult Index()
        {
            if (Session["UserID"]!=null)
            {
                _ViewCheckout view = ViewCheckout.GetData(Convert.ToInt32(Session["UserID"]));
                return View(view);
            }else
            {
                return View();
            }
       
        }
        public ActionResult PlaceOrder(_Order order)
        {
            if (Session["UserID"] != null)
            {
                order.UserID = Convert.ToInt32(Session["UserID"]);
                order.OrderStatus = 1;
                int OrderID = MD_Order.Save(order);
                return Json(OrderID, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View();
            }


        }
        public ActionResult Invoice()
        {
            _OrderItem items = new _OrderItem();
            items.OrderID = Convert.ToInt32(Request.QueryString["OrderID"]);
            var data = MD_OrderItem.GetTable(items);


            return View(data);
        }

        public ActionResult EditOrder(int OrderID,int OrderStatus)
        {
            _Order order = new _Order();
            order.OrderID = OrderID;
            var data = MD_Order.Get(order);
            data.FirstOrDefault().OrderID = OrderID;
            data.FirstOrDefault().OrderStatus = OrderStatus;
           int Order= MD_Order.Save(data.FirstOrDefault());
            return Json(Order,JsonRequestBehavior.AllowGet);

        }

        
    }
}