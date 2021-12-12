
using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_Cart
    {
        public static void Save(_Cart c)
        {
            SqlParameter[] para = new SqlParameter[9];
            para[0] = new SqlParameter("@CartID", c.CartID);
            para[1] = new SqlParameter("@ProductID", c.ProductID);
            para[2] = new SqlParameter("@UserID", c.UserID);
            para[3] = new SqlParameter("@UnitPrice", c.UnitPrice);
            para[4] = new SqlParameter("@Qty", c.Qty);
            para[5] = new SqlParameter("@TotalPrice", c.TotalPrice);
            para[6] = new SqlParameter("@ColorID", c.ColorID);
            para[7] = new SqlParameter("@SizeID", c.SizeID);
            para[8] = new SqlParameter("@Type",c.CartID==null ?ActionType.Save:ActionType.Update);
          
            Helper.ExecuteQuery("Sp_Cart", para);

        }
        public static List<_Cart> GetTable(_Cart c)
        {
            List<_Cart> lst = new List<_Cart>();
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@Type", ActionType.Select);
            para[1] = new SqlParameter("@ProductID", c.ProductID);
            para[2] = new SqlParameter("@UserID", c.UserID);
            para[3] = new SqlParameter("@CartID", c.CartID);
            DataTable dt = Helper.GetDataTable("Sp_Cart", para);
            foreach (DataRow r in dt.Rows)
            {
                _Cart crt = new _Cart();
                crt.CartID = Convert.ToInt32(r["CartID"]);
                crt.ProductID = Convert.ToInt32(r["ProductID"]);
                crt.UserID = Convert.ToInt32(r["UserID"]);
                crt.ProductImage = Convert.ToString(r["ProductImage"]);
                crt.ProductName = Convert.ToString(r["ProductName"]);
         
                crt.Qty = Convert.ToInt32(r["Qty"]);
                crt.UnitPrice = Convert.ToInt32(r["UnitPrice"]);
                crt.TotalPrice = Convert.ToInt32(r["TotalPrice"]);
                lst.Add(crt);
            }
            return lst;

        }
        public static _Cart GetTable(int CartID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Type", ActionType.Select);
            para[1] = new SqlParameter("@CartID", CartID);
            DataTable dt = Helper.GetDataTable("Sp_Cart", para);
            _Cart i = new _Cart();
            if (dt.Rows.Count > 0)
            {
                i.CartID = Convert.ToInt32(dt.Rows[0]["CartID"]);
                i.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                i.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                i.UnitPrice = Convert.ToInt32(dt.Rows[0]["UnitPrice"]);
                i.Qty = Convert.ToInt32(dt.Rows[0]["Qty"]);
                i.TotalPrice = Convert.ToInt32(dt.Rows[0]["TotalPrice"]);

            }
            return i;
        }
        
        public static void Delete(int CartID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Type", ActionType.Delete);
            para[1] = new SqlParameter("@CartID", CartID);
            Helper.ExecuteQuery("SP_Cart", para);
        }
    }
    public class _Cart
    {
        public int? CartID { get; set; }
    
        public int? ProductID { get; set; }
        public int? UserID { get; set; }
        public int? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public int MyProperty { get; set; }
        public string ProductImage { get; set; }

        public string ProductName { get; set; }
        public int ColorID { get; set; }
        public int SizeID { get; set; }





    }
}