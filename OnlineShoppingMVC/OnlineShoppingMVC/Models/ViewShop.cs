using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class ViewShop
    {
        public static  _ViewShop GetData()
        {
            _ViewShop view = new _ViewShop();
            view.Brand = MD_Brand.GetTable(new _Brand());
            view.Color = MD_Color.GetTable(new _Color());
            view.Category = MD_Category.GetTable(new _Category());
            view.SubCategory = MD_SubCategory.GetTable(new _SubCategory());
            view.Size = MD_Size.GetTable(new _Size());
            return view;
        }
    }
    public class _ViewShop
    {
        public List<_Brand> Brand { get; set; }
        public List<_Category> Category { get; set; }
        public List<_Size> Size { get; set; }

        public List<_SubCategory> SubCategory { get; set; }

        public List<_Color> Color { get; set; }
    }
}