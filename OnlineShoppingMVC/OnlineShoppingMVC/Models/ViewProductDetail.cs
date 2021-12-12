using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Models
{
    public class ViewProductDetail
    {
        public static _ViewProduct GetProduct(int  ProductID)
        { 
            _ViewProduct view = new _ViewProduct();
            _Product p = new _Product();
            _ProductColor color = new _ProductColor();
            _ProductSize size = new _ProductSize();
             p.ProductID = ProductID;
            size.ProductID = ProductID;
            color.ProductID = ProductID;
            
            view.Product = MD_Product.GetTable(p);


            p.CategoryID = view.Product[0].CategoryID;
            p.ProductID = null;
            view.RelatedProduct = MD_Product.GetTable(p);


            view.Color = MD_ProductColor.GetTable(color);
            view.Size = MD_ProductSize.GetTable(size);
            view.ColorItem = ddlcolor(view.Color);
            view.SizeItem = ddlsize(view.Size);
            return view;
        }
        public static List<SelectListItem> ddlcolor(List<_ProductColor> lst)
        {
           
            return lst.Select(a => new SelectListItem
            {
                Text = a.Color,
                Value = Convert.ToString(a.ColorID)
            }).ToList();
        }
        public static List<SelectListItem> ddlsize(List<_ProductSize> lst)
        {

            return lst.Select(a => new SelectListItem
            {
                Text = a.Size,
                Value = Convert.ToString(a.SizeID)
            }).ToList();
        }

    }
    public class _ViewProduct
    {
        public  List<_Product> Product { get; set; }
        public List<_ProductColor> Color { get; set; }
        public List<_ProductSize> Size { get; set; }
        public List<SelectListItem> ColorItem { get; set; }
        public List<SelectListItem> SizeItem { get; set; }
        public List<_Product> RelatedProduct { get; set; }
    }
}