
using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_WishList
    {
      
        public static void Save(_WishList w)
        {
            SqlParameter[] para = new SqlParameter[4];

            para[0] = new SqlParameter("@ProductID", w.ProductID);
            para[1] = new SqlParameter("@UserID", w.UserID);
            para[2] = new SqlParameter("@WishListID", w.WishListID);

            para[3] = new SqlParameter("@Type", w.WishListID == null ? ActionType.Save : ActionType.Update);

            Helper.ExecuteQuery("Sp_WishList", para);

        }
        public static List<_WishList> GetTable(_WishList c)
        {
            List<_WishList> lst = new List<_WishList>();
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@Type", ActionType.Select);
            para[1] = new SqlParameter("@ProductID", c.ProductID);
            para[2] = new SqlParameter("@UserID", c.UserID);
            para[3] = new SqlParameter("@WishListID", c.WishListID);
            DataTable dt = Helper.GetDataTable("Sp_WishList", para);
            foreach (DataRow r in dt.Rows)
            {
                _WishList crt = new _WishList();
                crt.WishListID = Convert.ToInt32(r["WishListID"]);
                crt.ProductID = Convert.ToInt32(r["ProductID"]);
                crt.ProductImage = Convert.ToString(r["ProductImage"]);
                crt.ProductName = Convert.ToString(r["ProductName"]);
                crt.UserID = Convert.ToInt32(r["UserID"]);

     

                lst.Add(crt);
            }
            return lst;

        }
        public static _WishList GetTable(int WishListID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@type", ActionType.Select);
            para[1] = new SqlParameter("@WishListID", WishListID);
            DataTable dt = Helper.GetDataTable("SP_WishList", para);
            _WishList i = new _WishList();
            if (dt.Rows.Count > 0)
            {
                i.WishListID = Convert.ToInt32(dt.Rows[0]["WhistListID"]);
                i.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                i.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);


            }
            return i;
        }
        public static void Delete(int WishListID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Type", ActionType.Delete);
            para[1] = new SqlParameter("@WishListID", WishListID);
            Helper.ExecuteQuery("Sp_WishList", para);
        }
       
    }
    public class _WishList
    {
        public int? WishListID { get; set; }
        public int? ProductID { get; set; }
        public int? UserID { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
    }
}