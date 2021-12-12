using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class ViewCheckout
    {
        public static _ViewCheckout GetData(int UserID)
        {
            _ViewCheckout view = new _ViewCheckout();
            _Cart cart = new _Cart();
            cart.UserID = UserID;
            view.Cart = MD_Cart.GetTable(cart);
            _User user = new _User();
            user.UserID = UserID;
            view.User = MD_User.GetTable(user);
            return view;
        }
    }
    public class _ViewCheckout
    {
        public List<_User> User { get; set; }
        public List<_Cart> Cart { get; set; }
    }
}