
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
    public class MD_Category
    {

        public static void Save(_Category ex)
        {
           
            SqlParameter[] Param = new SqlParameter[6];
            Param[0] = new SqlParameter("@CategoryName", ex.CategoryName);
            Param[1] = new SqlParameter("@CategoryID", ex.CategoryID);
            Param[2] = new SqlParameter("@CategoryStatus", ex.CategoryStatus);
            Param[3] = new SqlParameter("@CategoryImage", ex.CategoryImage);
            Param[4] = new SqlParameter("@CategoryDescription", ex.CategoryDescription);
            Param[5] = new SqlParameter("@Type", ex.CategoryID ==null ? ActionType.Save:ActionType.Update);
           
            Helper.ExecuteQuery("Sp_Category", Param);

        }
        public static List<_Category> GetTable(_Category c)
        {
            List<_Category> cat = new List<_Category>();
            SqlParameter[] Param = new SqlParameter[3];
            Param[0] = new SqlParameter("@CategoryName", c.CategoryName);
            Param[1] = new SqlParameter("@CategoryID", c.CategoryID);
            Param[2] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt= Helper.GetDataTable("Sp_Category", Param);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    Category x = new Category();
            //    x.CategoryID = Convert.ToInt32(dt.Rows[i]["CategoryID"]);
            //    x.CategoryName = Convert.ToString(dt.Rows[i]["CategoryName"]);
            //    x.Status = Convert.ToBoolean(dt.Rows[i]["Status"]);
            //    cat.Add(x);

            //}
            foreach (DataRow r in dt.Rows)
            {
                _Category x = new _Category();
                x.CategoryID = Convert.ToInt32(r["CategoryID"]);
                x.CategoryName = Convert.ToString(r["CategoryName"]);
                x.CategoryDescription = Convert.ToString(r["CategoryDescription"]);
                x.Status = Convert.ToString(r["Status"]);
                x.CategoryStatus = Convert.ToInt32(r["CategoryStatus"]);
                x.CategoryImage = Convert.ToString(r["CategoryImage"]);
                x.CategoryCount = Convert.ToString(r["CategoryCount"]);
                cat.Add(x);
            }

             

            return cat;
        }
        public static _Category GetTable(int CategoryID)
        {
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@CategoryID", CategoryID);
            Param[1] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_Category", Param);
            _Category cate = new _Category();
            if (dt.Rows.Count > 0)
            {
                cate.CategoryName = dt.Rows[0]["CategoryName"].ToString();
                cate.CategoryStatus = Convert.ToInt32(dt.Rows[0]["CategoryStatus"]);
                cate.CategoryImage = Convert.ToString(dt.Rows[0]["CategoryImage"]);
                cate.CategoryDescription = Convert.ToString(dt.Rows[0]["CategoryDescription"]);
                cate.CategoryID = Convert.ToInt32(dt.Rows[0]["CategoryID"]);
            }

            return cate;
        }
        public static void Delete(int CategoryID)
        {

            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@CategoryID", CategoryID);
            Param[1] = new SqlParameter("@Type",ActionType.Delete);
            Helper.ExecuteQuery("Sp_Category", Param);

        }
    }
    public class _Category
    {
   
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCount { get; set; }
        [AllowHtml]
        public string CategoryDescription { get; set; }
        public string CategoryImage { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public int CategoryStatus { get; set; }
        public string Status { get; set; }


    }
}