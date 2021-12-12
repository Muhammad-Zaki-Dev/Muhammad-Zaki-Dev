using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_ProductImage
    {

        public static List<_ProductImage> GetTable(_ProductImage c)
        {
            List<_ProductImage> lst = new List<_ProductImage>();
            SqlParameter[] Param = new SqlParameter[3];
            Param[0] = new SqlParameter("@ProductID", c.ProductID);
            Param[1] = new SqlParameter("@ProductImageID", c.ProductImageID);
            Param[2] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_ProductImage", Param);
            foreach (DataRow r in dt.Rows)
            {
                _ProductImage v = new _ProductImage();
                v.ProductImageID = Convert.ToInt32(r["ProductImageID"]);
                v.ProductImage = Convert.ToString(r["ProductImage"]);
                v.ProductID = Convert.ToInt32(r["ProductID"]);
                lst.Add(v);
            }
            return lst;
        }
        public static _ProductImage GetTable(int ProductImageID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@ProductImageID", ProductImageID);
            para[1] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_ProductImage", para);
            _ProductImage p = new _ProductImage();
            if (dt.Rows.Count > 0)
            {
                p.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                p.ProductImage = Convert.ToString(dt.Rows[0]["ProductImage"]);
                p.ProductImageID = Convert.ToInt32(dt.Rows[0]["ProductImageID"]);

            }
            return p;
        }
        public static void Save(_ProductImage p)
        {

            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@ProductID", p.ProductID);
            para[1] = new SqlParameter("@ProductImage", p.ProductImage);
            para[2] = new SqlParameter("@ProductImageID", p.ProductImageID);
            para[3] = new SqlParameter("@Type", p.ProductImageID == null ? ActionType.Save : ActionType.Update);


            Helper.ExecuteQuery("Sp_ProductImage", para);


        }
        public static void Delete(int ProductImageID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@ProductImageID", ProductImageID);
            para[1] = new SqlParameter("@Type", ActionType.Delete);
            Helper.ExecuteQuery("Sp_ProductImage", para);
        }
    }
    public class _ProductImage
    {
        public int? ProductImageID { get; set; }
        public int? ProductID { get; set; }
        public string ProductImage { get; set; }
    }
}