using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_ProductColor
    {
        public static List<_ProductColor> GetTable(_ProductColor c)
        {
            List<_ProductColor> lst = new List<_ProductColor>();
            SqlParameter[] Param = new SqlParameter[3];
            Param[0] = new SqlParameter("@ProductID", c.ProductID);
            Param[1] = new SqlParameter("@ColorID", c.ColorID);
            Param[2] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_ProductColor", Param);
            foreach (DataRow r in dt.Rows)
            {
                _ProductColor v = new _ProductColor();
                v.ColorID = Convert.ToInt32(r["ColorID"]);
                v.ProductID = Convert.ToInt32(r["ProductID"]);
                v.ProductColorID = Convert.ToInt32(r["ProductColorID"]);
                v.Color = Convert.ToString(r["Color"]);
                ;
                lst.Add(v);
            }
            return lst;
        }
        public static _ProductColor GetTable(int ProductColorID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@ProductColorID", ProductColorID);
            para[1] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_ProductColor", para);
            _ProductColor p = new _ProductColor();
            if (dt.Rows.Count > 0)
            {
                p.ColorID = Convert.ToInt32(dt.Rows[0]["ColorID"]);
                p.ProductColorID = Convert.ToInt32(dt.Rows[0]["ProductColorID"]);
                p.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                

            }
            return p;
        }
        public static void Save(_ProductColor p)
        {

            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@ColorID", p.ColorID);
            para[1] = new SqlParameter("@ProductColorID", p.ProductColorID);
            para[2] = new SqlParameter("@ProductID", p.ProductID);
            para[3] = new SqlParameter("@Type", p.ProductColorID == null ? ActionType.Save : ActionType.Update);


            Helper.ExecuteQuery("Sp_ProductColor", para);


        }
        public static void Delete(int ProductColorID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@ProductColorID", ProductColorID);
            para[1] = new SqlParameter("@Type", ActionType.Delete);
            Helper.ExecuteQuery("Sp_ProductColor", para);
        }
    }
    public class _ProductColor
    {
        public int? ProductColorID { get; set; }
        public int ColorID { get; set; }
        public int? ProductID { get; set; }
        public string Color { get; set; }
 


    }
}