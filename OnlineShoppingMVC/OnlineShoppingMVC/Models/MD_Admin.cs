
using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_Admin
    {
     

        public static void Save(_Admin ad)
        {
            SqlParameter[] para = new SqlParameter[10];
            para[0] = new SqlParameter("@AdminID", ad.AdminID);
            para[1] = new SqlParameter("@AdminName", ad.AdminName);
            para[2] = new SqlParameter("@UserName", ad.UserName);
            para[3] = new SqlParameter("@Password", ad.Password);
            para[4] = new SqlParameter("@AdminAddress", ad.AdminAddress);
            para[5] = new SqlParameter("@AdminContact", ad.AdminContact);
            para[6] = new SqlParameter("@AdminEmail", ad.AdminEmail);
            para[7] = new SqlParameter("@AdminStatus", ad.AdminStatus);
            para[8] = new SqlParameter("@Type", ad.AdminID == null ? ActionType.Save:ActionType.Update);
            para[9] = new SqlParameter("@AdminImage", ad.AdminImage);
            Helper.ExecuteQuery("Sp_Admin", para);

        }
        public static _Admin GetTable(int AdminID)
        {
            _Admin a = new _Admin();
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Type", ActionType.Select);
            para[1] = new SqlParameter("@AdminID", AdminID);
            DataTable dt = Helper.GetDataTable("Sp_Admin", para);
            if (dt.Rows.Count > 0)
            {
                a.AdminID = Convert.ToInt32(dt.Rows[0]["AdminID"]);
                a.AdminName = Convert.ToString(dt.Rows[0]["AdminName"]);
                a.AdminEmail = Convert.ToString(dt.Rows[0]["AdminEmail"]);
                a.AdminContact = Convert.ToString(dt.Rows[0]["AdminContact"]);
                a.AdminAddress = Convert.ToString(dt.Rows[0]["AdminAddress"]);
                a.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                a.Password = Convert.ToString(dt.Rows[0]["Password"]);
                a.AdminImage = Convert.ToString(dt.Rows[0]["AdminImage"]);

                a.AdminStatus = Convert.ToInt32(dt.Rows[0]["AdminStatus"]);
            }
            return a;
        }
        public static List<_Admin> GetTable(_Admin a)
        {
            List<_Admin> lst = new List<_Admin>();
            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("@Type", ActionType.Select);
            para[1] = new SqlParameter("@AdminID", a.AdminID);
            para[2] = new SqlParameter("@AdminName", a.AdminName);
            para[3] = new SqlParameter("@AdminEmail", a.AdminEmail);
            para[4] = new SqlParameter("@UserName", a.UserName);
            para[5] = new SqlParameter("@Password", a.Password);

            DataTable dt = Helper.GetDataTable("Sp_Admin", para);
            foreach (DataRow r in dt.Rows)
            {
                _Admin ad = new _Admin();
                ad.AdminID = Convert.ToInt32(r["AdminID"]);
                ad.AdminName = Convert.ToString(r["AdminName"]);
                ad.AdminEmail = Convert.ToString(r["AdminEmail"]);
                ad.AdminContact = Convert.ToString(r["AdminContact"]);
                ad.AdminAddress = Convert.ToString(r["AdminAddress"]);
                ad.UserName = Convert.ToString(r["UserName"]);
                ad.Password = Convert.ToString(r["Password"]);
                ad.AdminImage = Convert.ToString(r["AdminImage"]);
                ad.Status = Convert.ToString(r["Status"]);
                ad.AdminStatus = Convert.ToInt32(r["AdminStatus"]);
                lst.Add(ad);
            }
            return lst;
        }
        public static void Delete(int AdminID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Type", ActionType.Delete);
            para[1] = new SqlParameter("@AdminID", AdminID);
            Helper.ExecuteQuery("Sp_Admin", para);
        }

    }
    public class _Admin
    {
        public int? AdminID { get; set; }
        public string AdminName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AdminEmail { get; set; }
        public string AdminContact { get; set; }
        public string AdminAddress { get; set; }
        public string AdminImage { get; set; }
        public int AdminStatus { get; set; }
        public string Status { get; set; }
        public HttpPostedFileBase Image { get; set; }
    }
}