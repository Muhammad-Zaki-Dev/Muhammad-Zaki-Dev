
using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Models
{
    public class MD_Product
    {
        public static int Save(_Product p)
        {

            SqlParameter[] para = new SqlParameter[15];
            para[0] = new SqlParameter("@ProductName", p.ProductName);
            para[1] = new SqlParameter("@ProductStatus", p.ProductStatus);
            para[2] = new SqlParameter("@CategoryID", p.CategoryID);
            para[3] = new SqlParameter("@SubCategoryID", p.SubCategoryID);
            para[4] = new SqlParameter("@ProductID", p.ProductID);
            para[5] = new SqlParameter("@ProductDescription", p.ProductDescription);
            para[6] = new SqlParameter("@ProductPrice", p.ProductPrice);
            para[7] = new SqlParameter("@ProductImage", p.ProductImage);
            para[8] = new SqlParameter("@BestSeller", p.BestSeller);
            para[9] = new SqlParameter("@NewArrival", p.NewArrival);
            para[10] = new SqlParameter("@Discount", p.Discount);
            para[11] = new SqlParameter("@SpecialOffer", p.SpecialOffer);
            para[12] = new SqlParameter("@NewID", SqlDbType.Int);
            para[12].Direction = ParameterDirection.Output;
            para[13] = new SqlParameter("@Trending", p.Trending);


            para[14] = new SqlParameter("@Type", p.ProductID == null ? ActionType.Save : ActionType.Update);


          return  Helper.OutputExecuteQuery("Sp_Product", para);
        }


        public static List<_Product> GetTable(_Product p)
        {

            List<_Product> lst = new List<_Product>();

            SqlParameter[] para = new SqlParameter[10];
            para[0] = new SqlParameter("@Type", ActionType.Select);
            para[1] = new SqlParameter("@ProductID", p.ProductID);
            para[2] = new SqlParameter("@CategoryID", p.CategoryID);
            para[3] = new SqlParameter("@SubCategoryID", p.SubCategoryID);
           
            para[4] = new SqlParameter("@ProductName", p.ProductName);
            para[5] = new SqlParameter("@ProductStatus", p.ProductStatus);
            para[6] = new SqlParameter("@BestSeller", p.BestSeller);
            para[7] = new SqlParameter("@SpecialOffer", p.SpecialOffer);
            para[8] = new SqlParameter("@NewArrival", p.NewArrival);
            para[9] = new SqlParameter("@Trending", p.Trending);
        
            DataTable dt = Helper.GetDataTable("Sp_Product", para);

            foreach (DataRow r in dt.Rows)
            {
                _Product pro = new _Product();
                pro.ProductID = Convert.ToInt32(r["ProductID"]);
                pro.ProductName = Convert.ToString(r["ProductName"]);
                pro.CategoryID = Convert.ToInt32(r["CategoryID"]);
                pro.CategoryName = Convert.ToString(r["CategoryName"]);
            
                pro.SubCategoryName = Convert.ToString(r["SubCategoryName"]);
                pro.SubCategoryID = Convert.ToInt32(r["SubCategoryID"]);
            
                pro.ProductDescription = Convert.ToString(r["ProductDescription"]);
                pro.ProductPrice = Convert.ToInt32(r["ProductPrice"]);
                pro.Discount = Convert.ToInt32(r["Discount"]);
                pro.Trending = Convert.ToInt32(r["Trending"]);
           
               
                pro.ProductImage = Convert.ToString(r["ProductImage"]);
                pro.ProductStatus = Convert.ToInt32(r["ProductStatus"]);
                pro.Status = Convert.ToString(r["Status"]);
                pro.BestSeller = Convert.ToInt32(r["BestSeller"]);
                pro.NewArrival = Convert.ToInt32(r["NewArrival"]);
                pro.SpecialOffer = Convert.ToInt32(r["SpecialOffer"]);
                lst.Add(pro);

            }
            return lst;

        }
        public static _Product GetTable(int ProductID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@ProductID", ProductID);
            para[1] = new SqlParameter("@type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("SP_Product", para);
            _Product p = new _Product();
            if (dt.Rows.Count > 0)
            {
                p.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                p.ProductName = dt.Rows[0]["ProductName"].ToString();
                p.CategoryID = Convert.ToInt32(dt.Rows[0]["CategoryID"]);
                p.SubCategoryID = Convert.ToInt32(dt.Rows[0]["SubCategoryID"]);
                p.ProductDescription = dt.Rows[0]["ProductDescription"].ToString();
                p.ProductPrice = Convert.ToInt32(dt.Rows[0]["ProductPrice"]);
       
                p.ProductImage = Convert.ToString(dt.Rows[0]["ProductImage"]);
                p.ProductStatus = Convert.ToInt32(dt.Rows[0]["ProductStatus"]);
       
                p.Discount = Convert.ToInt32(dt.Rows[0]["Discount"]);
                p.Trending = Convert.ToInt32(dt.Rows[0]["Trending"]);

            }
            return p;
        }
        public static void Delete(int ProductID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Type", ActionType.Delete);
            para[1] = new SqlParameter("@ProductID", ProductID);

            Helper.ExecuteQuery("SP_Product", para);
        }


    }
    public class _Product

    {
        public int? ProductID { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int? SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public int Trending { get; set; }
        public int? ColorID { get; set; }
        public string Color { get; set; }
        public int? SizeID { get; set; }
        public string Size { get; set; }
        public int? UnitID { get; set; }
        public string Unit { get; set; }
        public string ProductName { get; set; }
        [AllowHtml]
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public HttpPostedFileBase Image { get; set; }
        [Required]
        public decimal? ProductPrice { get; set; }
        public int? ProductStatus { get; set; }
        public string Status { get; set; }
        public int? BestSeller { get; set; }
        public int? NewArrival { get; set; }
        public int? SpecialOffer { get; set; }
        public int NewsID { get; set; }
        public int Discount { get; set; }
        public List<SelectListItem> ddlCategory { get; set; }
        public List<SelectListItem> ddlUnit { get; set; }
        public List<SelectListItem> ddlSize { get; set; }
        public List<SelectListItem> ddlColor { get; set; }





    }
}
