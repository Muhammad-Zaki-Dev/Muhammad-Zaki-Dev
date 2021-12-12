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
    public class MD_News
    {
        public static void Save(_News ad)
        {
            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter("@NewsDescription", ad.NewsDescription);
            para[1] = new SqlParameter("@NewsID", ad.NewsID);
            para[2] = new SqlParameter("@NewsImage", ad.NewsImage);
            para[3] = new SqlParameter("@NewsTitle", ad.NewsTitle);
            para[4] = new SqlParameter("@Status", ad.Status);
            para[5] = new SqlParameter("@PostedDate", ad.PostedDate);
            
            para[6] = new SqlParameter("@Type", ad.NewsID == null ? ActionType.Save : ActionType.Update);

            Helper.ExecuteQuery("SP_News", para);

        }
        public static _News GetTable(int NewsID)
        {
            _News ad = new _News();
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Type", ActionType.Select);
            para[1] = new SqlParameter("@NewsID", NewsID);
            DataTable dt = Helper.GetDataTable("SP_News", para);
            foreach (DataRow r in dt.Rows)
            {

                ad.NewsID = Convert.ToInt32(r["NewsID"]);
                ad.PostedDate = Convert.ToDateTime(r["PostedDate"]);
                ad.NewsDescription = Convert.ToString(r["NewsDescription"]);
                ad.NewsImage = Convert.ToString(r["NewsImage"]);
                ad.NewsTitle = Convert.ToString(r["NewsTitle"]);
                ad.Status = Convert.ToInt32(r["Status"]);
              
             


            }
            return ad;
        }
        public static List<_News> GetTable(_News a)
        {
            List<_News> lst = new List<_News>();
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@Type", ActionType.Select);
            para[1] = new SqlParameter("@NewsID", a.NewsID);
            para[2] = new SqlParameter("@PostedDate", a.PostedDate);
            para[3] = new SqlParameter("@NewsTitle", a.NewsTitle);
           

            DataTable dt = Helper.GetDataTable("SP_News", para);
            foreach (DataRow r in dt.Rows)
            {
                _News ad = new _News();
                ad.NewsTitle = Convert.ToString(r["NewsTitle"]);
                ad.NewsImage = Convert.ToString(r["NewsImage"]);
                ad.NewsID = Convert.ToInt16(r["NewsID"]);
                ad.NewsDescription = Convert.ToString(r["NewsDescription"]);
                ad.PostedDate =Convert.ToDateTime( Convert.ToDateTime(r["PostedDate"]).ToShortDateString());
                ad.StStatus = Convert.ToString(r["StStatus"]);
                ad.Status = Convert.ToInt16(r["Status"]);
              


                lst.Add(ad);
            }
            return lst;
        }
        public static void Delete(int NewsID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Type", ActionType.Delete);
            para[1] = new SqlParameter("@NewsID", NewsID);
            Helper.ExecuteQuery("SP_News", para);
        }
    }
    public class _News
    {
        public int? NewsID { get; set; }
        public string NewsTitle { get; set; }
        [AllowHtml]
        public string NewsDescription { get; set; }

        public DateTime? PostedDate { get; set; }
        public int Status { get; set; }
        public string NewsImage { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string StStatus { get; set; }

    }
}