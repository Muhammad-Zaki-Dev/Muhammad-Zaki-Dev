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
    public class MD_Blog
    {
        public static void Save(_Blog ad)
        {
            SqlParameter[] para = new SqlParameter[9];
            para[0] = new SqlParameter("@BlogDescription", ad.BlogDescription);
            para[1] = new SqlParameter("@BlogID", ad.BlogID);
            para[2] = new SqlParameter("@BlogImage", ad.BlogImage);
            para[3] = new SqlParameter("@BlogStatus", ad.BlogStatus);
            para[4] = new SqlParameter("@POstTitle", ad.POstTitle);
            para[5] = new SqlParameter("@PostedDate", ad.PostedDate);
            para[6] = new SqlParameter("@IsShowComment", ad.IsShowComment);
            para[7] = new SqlParameter("@AdminiD", ad.AdminiD);
            para[8] = new SqlParameter("@Type", ad.BlogID == null ? ActionType.Save : ActionType.Update);
          
            Helper.ExecuteQuery("Sp_Blog", para);

        }
        public static _Blog GetTable(int BlogID)
        {
            _Blog ad = new _Blog();
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Type", ActionType.Select);
            para[1] = new SqlParameter("@BlogID", BlogID);
            DataTable dt = Helper.GetDataTable("Sp_Blog", para);
            foreach (DataRow r in dt.Rows)
            {
              
                ad.BlogID = Convert.ToInt32(r["BlogID"]);
                ad.PostedDate = Convert.ToDateTime(r["PostedDate"]);
                ad.POstTitle = Convert.ToString(r["POstTitle"]);
                ad.IsShowComment = Convert.ToInt32(r["IsShowComment"]);
                ad.BlogStatus = Convert.ToInt32(r["BlogStatus"]);
                ad.AdminiD = Convert.ToInt32(r["AdminiD"]);
                ad.BlogDescription = Convert.ToString(r["BlogDescription"]);
                ad.BlogImage = Convert.ToString(r["BlogImage"]);


            }
            return ad;
        }
        public static List<_Blog> GetTable(_Blog a)
        {
            List<_Blog> lst = new List<_Blog>();
            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("@Type", ActionType.Select);
            para[1] = new SqlParameter("@BlogID", a.BlogID);
            para[2] = new SqlParameter("@PostedDate", a.PostedDate);
            para[3] = new SqlParameter("@POstTitle", a.POstTitle);
            para[4] = new SqlParameter("@IsShowComment", a.IsShowComment);
            para[5] = new SqlParameter("@BlogStatus", a.BlogStatus);

            DataTable dt = Helper.GetDataTable("Sp_Blog", para);
            foreach (DataRow r in dt.Rows)
            {
                _Blog ad = new _Blog();
                ad.BlogID = Convert.ToInt32(r["BlogID"]);
                ad.PostedDate = Convert.ToDateTime(r["PostedDate"]);
                ad.POstTitle = Convert.ToString(r["POstTitle"]);
                ad.IsShowComment = Convert.ToInt32(r["IsShowComment"]);
                ad.BlogStatus = Convert.ToInt32(r["BlogStatus"]);
                ad.AdminiD = Convert.ToInt32(r["AdminiD"]);
                ad.BlogDescription = Convert.ToString(r["BlogDescription"]);
                ad.BlogImage = Convert.ToString(r["BlogImage"]);

           
                lst.Add(ad);
            }
            return lst;
        }
        public static void Delete(int BlogID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Type", ActionType.Delete);
            para[1] = new SqlParameter("@BlogID", BlogID);
            Helper.ExecuteQuery("Sp_Blog", para);
        }
    }
    public class _Blog
    {
        public int? BlogID { get; set; }
        public int? AdminiD { get; set; }
        public string POstTitle { get; set; }
        public string BlogImage { get; set; }
        public HttpPostedFileBase Image { get; set; }
        [AllowHtml]
        public string BlogDescription { get; set; }
        public int? IsShowComment { get; set; }
        public DateTime? PostedDate { get; set; }
        public int? BlogStatus { get; set; }
        public int Status { get; set; }
    }
}
