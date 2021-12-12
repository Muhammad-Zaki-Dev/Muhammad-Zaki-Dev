using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Models
{
    public class VIewDashboard
    {
        public static _ViewDashBoard GetDashBoardDetail(int UserID)
        { _ViewDashBoard view = new _ViewDashBoard();
            _User user = new _User();
            //_Order ord = new _Order();
            //ord.UserID = UserID;
            user.UserID = UserID;
            view.User = MD_User.GetTable(user);
            //view.Order = MD_Order.Get(ord);
            return view;
        }
        
    }
    public class _ViewDashBoard
    {
        public List<_User> User { get; set; }
        //public List<_Order> Order { get; set; }
    }
}