
using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Models
{
    public class MD_SubCategory
    {
        public static void save(_SubCategory x)
        {
    
            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("@SubCategoryID", x.SubCategoryID);
            para[1] = new SqlParameter("@SubCategoryName", x.SubCategoryName);
            para[2] = new SqlParameter("@SubCategoryStatus", x.SubCategoryStatus);
            para[3] = new SqlParameter("@CategoryID", x.CategoryID);
            para[4] = new SqlParameter("@SubCategoryImage", x.SubCategoryImage);
            para[5] = new SqlParameter("@Type",x.SubCategoryID==null? ActionType.Save:ActionType.Update);
            
            Helper.ExecuteQuery("Sp_Subcategory", para);
        }
        public static void Delete(int SubCategoryID)
        {
            
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SubCategoryID", SubCategoryID);
            para[1] = new SqlParameter("@Type", ActionType.Delete);
            Helper.ExecuteQuery("Sp_Subcategory", para);

        }
        public static List<_SubCategory> GetTable(_SubCategory sub)
        {
            List<_SubCategory> lst = new List<_SubCategory>();
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@Type", ActionType.Select);
            para[1] = new SqlParameter("@SubcategoryID", sub.SubCategoryID);
            para[2] = new SqlParameter("@CategoryID", sub.CategoryID);
            para[3] = new SqlParameter("@SubCategoryName", sub.SubCategoryName);
            DataTable dt= Helper.GetDataTable("Sp_SubCategory",para);
            foreach (DataRow r in dt.Rows)
            {
                _SubCategory s = new _SubCategory();
                s.CategoryID = Convert.ToInt32(r["CategoryID"]);
                s.SubCategoryID = Convert.ToInt32(r["SubCategoryID"]);
                s.SubCategoryName = Convert.ToString(r["SubCategoryName"]);
                s.SubCategoryStatus = Convert.ToInt32(r["SubCategoryStatus"]);
                s.SubCategoryImage = Convert.ToString(r["SubCategoryImage"]);
                s.CategoryName = Convert.ToString(r["CategoryName"]);
                s.SubCategoryCount = Convert.ToString(r["SubCategoryCount"]);
                s.Status = Convert.ToString(r["Status"]);
                lst.Add(s);
            }
            return lst;
        }
        public static _SubCategory GetTable(int SubCategoryID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SubCategoryID", SubCategoryID);
            para[1] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("SP_Subcategory",para);
            _SubCategory s = new _SubCategory();
            if (dt.Rows.Count > 0)
            {
                s.CategoryID =Convert.ToInt32( dt.Rows[0]["CategoryID"]);
                s.SubCategoryID = Convert.ToInt32(dt.Rows[0]["SubCategoryID"]);
                s.SubCategoryName = dt.Rows[0]["SubCategoryName"].ToString();
             
          
                s.SubCategoryStatus = Convert.ToInt32(dt.Rows[0]["SubCategoryStatus"]);

            }
            return s;
        }
   

    }
    public class _SubCategory
    {
        public int? SubCategoryID { get; set; }
        public int? CategoryID { get; set; }
        public List<SelectListItem> ddlCategory { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryCount { get; set; }
        public string SubCategoryImage { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public int SubCategoryStatus { get; set; }
        public string CategoryName { get; set; }
        public string Status { get; set; }

    }
}