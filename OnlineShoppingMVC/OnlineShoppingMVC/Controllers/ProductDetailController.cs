using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class ProductDetailController : Controller
    {
       static int  CategoryID, SubCategoryID;
        // GET: ProductDetail
        public ActionResult Index(/*int ProductID*/)
        {
            _ViewProduct view = new _ViewProduct();
            view = ViewProductDetail.GetProduct(Convert.ToInt32(Request.QueryString["ProductID"]));
            return View(view);
        }
        public ActionResult ShowProduct()
        {
            CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
            SubCategoryID = Convert.ToInt32(Session["SubCategoryID"]);
           var data= ViewProductShop.GetData();
            return View(data);
        }
        
        public ActionResult ViewProduct()
        {
            List<_Product> lst = new List<_Product>();
            _Product product = new _Product();

            if (CategoryID > 0)
            {
                product.CategoryID = CategoryID;

                lst = MD_Product.GetTable(product);
            }
            else if (SubCategoryID > 0)
            {
                product.SubCategoryID = SubCategoryID;
                lst = MD_Product.GetTable(product);
            }
            else
            {
                lst = MD_Product.GetTable(new _Product());
            }
            return PartialView("ViewProduct",lst);

        }
        public ActionResult ByCategoryID(int CategoryID)
        {
            List<_Product> lst = new List<_Product>();
            _Product product = new _Product();
            product.CategoryID = CategoryID;

            lst = MD_Product.GetTable(product);
            return PartialView("ViewProduct", lst);
        }
        public ActionResult BySubCategoryID(int CategoryID,int SubCategoryID)
        {
            List<_Product> lst = new List<_Product>();
            _Product product = new _Product();
            product.SubCategoryID = SubCategoryID;

            lst = MD_Product.GetTable(product);
            return PartialView("ViewProduct", lst);
        }


    }
}