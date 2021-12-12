
using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_User
    {
        public static void Save(_User c)
        {
            SqlParameter[] para = new SqlParameter[11];
            para[0] = new SqlParameter("@UserAddress", c.UserAddress);
            para[1] = new SqlParameter("@UserContact", c.UserContact);
            para[2] = new SqlParameter("@UserEmail", c.UserEmail);
            para[3] = new SqlParameter("@UserGender", c.UserGender);
            para[4] = new SqlParameter("@UserID", c.UserID);
            para[5] = new SqlParameter("@UserImage", c.UserImage);
            para[6] = new SqlParameter("@UserName", c.UserName);
            para[7] = new SqlParameter("@UserStatus", c.UserStatus);
            para[8] = new SqlParameter("@Password", c.Password);
            para[9] = new SqlParameter("@Type", c.UserID==null?ActionType.Save:ActionType.Update);
            para[10] = new SqlParameter("@ZipCode", c.ZipCode);
            Helper.ExecuteQuery("Sp_User", para);
           
          
        }
        public static List<_User> GetTable(_User x )
        {
            List<_User> lst = new List<_User>();
            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("@type", ActionType.Select);
            para[1] = new SqlParameter("@UserEmail", x.UserEmail);
            para[2] = new SqlParameter("@Password", x.Password);
            para[3] = new SqlParameter("@UserID", x.UserID);
            para[4] = new SqlParameter("@UserName", x.UserName);
            para[5] = new SqlParameter("@UserStatus", x.UserStatus);
            DataTable dt= Helper.GetDataTable("Sp_User", para);
            foreach (DataRow r in dt.Rows)
            {
                _User c = new _User();
                c.UserAddress = Convert.ToString(r["UserAddress"]);
                c.UserContact = Convert.ToString(r["UserContact"]);
                c.UserEmail = Convert.ToString(r["UserEmail"]);
                c.UserGender =Convert.ToInt32( r["UserGender"]);
                c.UserID =Convert.ToInt32( r["UserID"]);
                c.UserImage =Convert.ToString( r["UserImage"]);
                c.UserName =Convert.ToString( r["UserName"]);
                c.UserStatus =Convert.ToInt32( r["UserStatus"]);
                c.Password = Convert.ToString(r["Password"]);
                c.ZipCode = Convert.ToString(r["ZipCode"]);
                
                lst.Add(c);
            }
            return lst;
        }
        public static _User GetTable(int UserID)
        {
            _User c = new _User();
           
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Type", ActionType.Select);
            para[1] = new SqlParameter("@UserID", UserID);
            DataTable dt= Helper.GetDataTable("Sp_User", para);

            foreach (DataRow r in dt.Rows)
            {
               
                c.UserAddress = Convert.ToString(r["UserAddress"]);
                c.UserContact = Convert.ToString(r["UserContact"]);
                c.UserEmail = Convert.ToString(r["UserEmail"]);
                c.UserGender = Convert.ToInt32(r["UserGender"]);
                c.UserID = Convert.ToInt32(r["UserID"]);
                c.UserImage = Convert.ToString(r["UserImage"]);
                c.UserName = Convert.ToString(r["UserName"]);
                c.UserStatus = Convert.ToInt32(r["UserStatus"]);
                c.Password = Convert.ToString(r["Password"]);
                c.ZipCode = Convert.ToString(r["ZipCode"]);

              
            }
            return c;
        }
       
        public static void Delete(int UserID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Type", ActionType.Delete);
            para[1] = new SqlParameter("@UserID", UserID);
             Helper.ExecuteQuery("Sp_User", para);
        }


    }
    public class _User
    {
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserEmail { get; set; }
        public string UserContact { get; set; }
        public string UserAddress { get; set; }
        public int UserGender { get; set; }
        public string UserImage { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public int UserStatus { get; set; }
        public string ZipCode { get; set; }
    }

}
