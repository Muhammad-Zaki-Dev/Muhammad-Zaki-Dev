using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{

    public class ViewModel
    {

        public static _ViewModel GetViewModel()
        {
            _ViewModel view = new _ViewModel();
            _Product product = new _Product();


            product.BestSeller = 1;
            view.ProductsBestSaler = MD_Product.GetTable(product);

            product.BestSeller = null;
            product.SpecialOffer = 1;
            view.ProductsSpeacialOffer = MD_Product.GetTable(product);

            product.BestSeller = null;
            product.SpecialOffer = null;
            product.NewArrival = 1;
            view.ProductsNewArrival = MD_Product.GetTable(product);

            view.Category = MD_Category.GetTable(new _Category());
            view.SubCategory = MD_SubCategory.GetTable(new _SubCategory());


            view.Brand =MD_Brand.GetTable(new _Brand());
            view.News = MD_News.GetTable(new _News());
            return view;
        }
    }
    public class _ViewModel
    {
        public List<_Product> ProductsNewArrival { get; set; }
        public List<_Product> ProductsBestSaler { get; set; }
        public List<_Product> ProductsSpeacialOffer { get; set; }
        public List<_Category> Category { get; set; }
        public List<_SubCategory> SubCategory { get; set; }
        public List<_Brand> Brand { get; set; }
        public List<_News> News { get; set; }
    }
}