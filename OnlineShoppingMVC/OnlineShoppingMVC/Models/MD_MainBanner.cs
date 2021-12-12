using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_MainBanner
    {
        public static List<_MainBanner> GetTable(_MainBanner c)
        {
            List<_MainBanner> lst = new List<_MainBanner>();
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@BannerID", c.BannerID);
         
            Param[1] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("SP_MainBanner", Param);
            foreach (DataRow r in dt.Rows)
            {
                _MainBanner v = new _MainBanner();
                v.BannerID = Convert.ToInt32(r["BannerID"]);
                v.BannerImage = Convert.ToString(r["BannerImage"]);
          
                lst.Add(v);
            }
            return lst;
        }
        public static _MainBanner GetTable(int BannerID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@BannerID", BannerID);
            para[1] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("SP_MainBanner", para);
            _MainBanner p = new _MainBanner();
            if (dt.Rows.Count > 0)
            {
                p.BannerID = Convert.ToInt32(dt.Rows[0]["BannerID"]);
                p.BannerImage = Convert.ToString(dt.Rows[0]["BannerImage"]);
            

            }
            return p;
        }
        public static void SaveBanner(_MainBanner p)
        {

            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@BannerID", p.BannerID);
            para[1] = new SqlParameter("@BannerImage", p.BannerImage);
          
            para[2] = new SqlParameter("@Type", p.BannerID == null ? ActionType.Save : ActionType.Update);


            Helper.ExecuteQuery("SP_MainBanner", para);


        }
        public static void Delete(int BannerID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@BannerID", BannerID);
            para[1] = new SqlParameter("@Type", ActionType.Delete);
            Helper.ExecuteQuery("SP_MainBanner", para);
        }
    }
    public class _MainBanner
    {
        public int? BannerID { get; set; }
        public string BannerImage { get; set; }
        public HttpPostedFileBase Image { get; set; }

    }
}