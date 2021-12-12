using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_Brand
    {
        public static List<_Brand> GetTable(_Brand c)
        {
            List<_Brand> lst = new List<_Brand>();
            SqlParameter[] Param = new SqlParameter[3];
            Param[0] = new SqlParameter("@BrandName", c.BrandName);
            Param[1] = new SqlParameter("@BrandID", c.BrandID);
            Param[2] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("SP_Brand", Param);
            foreach (DataRow r in dt.Rows)
            {
                _Brand v = new _Brand();
                v.BrandID = Convert.ToInt32(r["BrandID"]);
                v.BrandImage = Convert.ToString(r["BrandImage"]);
                v.BrandName = Convert.ToString(r["BrandName"]);
                v.Status = Convert.ToInt32(r["Status"]);
                lst.Add(v);
            }
            return lst;
        }
        public static _Brand GetTable(int BrandID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@BrandID", BrandID);
            para[1] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("SP_Brand", para);
            _Brand p = new _Brand();
            if (dt.Rows.Count > 0)
            {
                p.BrandID = Convert.ToInt32(dt.Rows[0]["BrandID"]);
                p.BrandName = Convert.ToString(dt.Rows[0]["BrandName"]);
                p.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                p.BrandImage = dt.Rows[0]["BrandImage"].ToString();

            }
            return p;
        }
        public static void Save(_Brand p)
        {

            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@BrandName", p.BrandName);
            para[1] = new SqlParameter("@BrandImage", p.BrandImage);
            para[2] = new SqlParameter("@Status", p.Status);
            para[3] = new SqlParameter("@Type", p.BrandID == null ? ActionType.Save : ActionType.Update);


            Helper.ExecuteQuery("SP_Brand", para);


        }
        public static void Delete(int BrandID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@BrandID", BrandID);
            para[1] = new SqlParameter("@Type", ActionType.Delete);
            Helper.ExecuteQuery("SP_Brand", para);
        }
    }
    public class _Brand
    {
        public int? BrandID { get; set; }
        public string BrandName { get; set; }
        public string BrandImage { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public int Status { get; set; }




    }
}