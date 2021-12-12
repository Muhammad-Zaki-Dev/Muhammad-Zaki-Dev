using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class ViewCustomerDashBoard
    {
        public static _ViewCustomerDashBoard Getdata(int UserID)
        {
            _ViewCustomerDashBoard view = new _ViewCustomerDashBoard();
            _Order order = new _Order();
            _User user = new _User();
            order.UserID = UserID;
            user.UserID = UserID;

            view.Order = MD_Order.Get(order);
            view.User = MD_User.GetTable(user);
            return view;
        }
    }
    public class _ViewCustomerDashBoard
    {
        public List<_Order> Order { get; set; }
        public List<_User> User { get; set; }
    }

}