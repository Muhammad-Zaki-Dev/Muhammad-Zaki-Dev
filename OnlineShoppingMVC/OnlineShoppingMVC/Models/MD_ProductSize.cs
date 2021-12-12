using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_ProductSize
    {
        public static List<_ProductSize> GetTable(_ProductSize c)
        {
            List<_ProductSize> lst = new List<_ProductSize>();
            SqlParameter[] Param = new SqlParameter[4];
            Param[0] = new SqlParameter("@ProductSizeID", c.ProductSizeID);
            Param[1] = new SqlParameter("@SizeID", c.SizeID);
            Param[2] = new SqlParameter("@ProductID", c.ProductID);
            Param[3] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("SP_ProductSize", Param);
            foreach (DataRow r in dt.Rows)
            {
                _ProductSize v = new _ProductSize();
                v.SizeID = Convert.ToInt32(r["SizeID"]);
                v.ProductSizeID = Convert.ToInt32(r["ProductSizeID"]);
                v.ProductID = Convert.ToInt32(r["ProductID"]);
                v.Size = Convert.ToString(r["Size"]);
              
                lst.Add(v);
            }
            return lst;
        }
        public static _ProductSize GetTable(int ProductSizeID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@ProductSizeID", ProductSizeID);
            para[1] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_ProductSize", para);
            _ProductSize p = new _ProductSize();
            if (dt.Rows.Count > 0)
            {
                p.ProductSizeID = Convert.ToInt32(dt.Rows[0]["ProductSizeID"]);
                p.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                p.SizeID = Convert.ToInt32(dt.Rows[0]["SizeID"]);
        

            }
            return p;
        }
        public static void Save(_ProductSize p)
        {

            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@SizeID", p.SizeID);
            para[1] = new SqlParameter("@ProductSizeID", p.ProductSizeID);
            para[2] = new SqlParameter("@ProductID", p.ProductID);
            para[3] = new SqlParameter("@Type", p.ProductSizeID == null ? ActionType.Save : ActionType.Update);


            Helper.ExecuteQuery("Sp_ProductSize", para);


        }
        public static void Delete(int ProductSizeID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@ProductSizeID", ProductSizeID);
            para[1] = new SqlParameter("@Type", ActionType.Delete);
            Helper.ExecuteQuery("Sp_ProductSize", para);
        }
    }
    public class _ProductSize
    {
        public int? ProductSizeID { get; set; }
        public int? ProductID { get; set; }

        public int SizeID { get; set; }
        public string Size { get; set; }


    }
}