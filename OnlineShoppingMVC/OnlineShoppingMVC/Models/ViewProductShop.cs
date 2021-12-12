using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Models
{
    public class ViewProductShop
    {
        public static _ViewProductShop GetData()
        {
            _ViewProductShop shop = new _ViewProductShop();
            shop.Category = MD_Category.GetTable(new _Category());
            shop.SubCategory = MD_SubCategory.GetTable(new _SubCategory());
            shop.Color = MD_Color.GetTable(new _Color());
            shop.Size = MD_Size.GetTable(new _Size());
            return shop;
        }
    }
    public class _ViewProductShop
    {
        public List<_Category> Category { get; set; }
        public List<_SubCategory> SubCategory { get; set; }
        public List<_Color> Color { get; set; }
        public List<_Size> Size { get; set; }


    }
}