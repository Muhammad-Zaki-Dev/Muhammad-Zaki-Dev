
using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_Order
    {
        public static int Save(_Order i)
        {


            SqlParameter[] para = new SqlParameter[12];

            para[0] = new SqlParameter("@OrderID", i.OrderID);
            para[1] = new SqlParameter("@UserID", i.UserID);
            para[2] = new SqlParameter("@MethodID", i.MethodID);
            para[3] = new SqlParameter("@OrderStatus", i.OrderStatus);
            para[4] = new SqlParameter("@ZipCode", i.ZipCode);
            para[4] = new SqlParameter("@UserGender", i.UserGender);
            para[5] = new SqlParameter("@UserName", i.UserName);
            para[6] = new SqlParameter("@UserEmail", i.UserEmail);
            para[7] = new SqlParameter("@UserContact", i.UserContact);
            para[8] = new SqlParameter("@UserAddress", i.UserAddress);
            para[9] = new SqlParameter("@Description", i.Description);
            para[10] = new SqlParameter("@Type", i.OrderID == null ? ActionType.Save : ActionType.Update);
            para[11] = new SqlParameter("@NewID", SqlDbType.Int);
            para[11].Direction = ParameterDirection.Output;
         
               return Helper.OutputExecuteQuery("Sp_Order", para);
               
           
        }
        public static List<_Order> Get(_Order o)
        {

            List<_Order> lst = new List<_Order>();
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@UserID", o.UserID);
            para[1] = new SqlParameter("@OrderID", o.OrderID);
            para[2] = new SqlParameter("@OrderStatus", o.OrderStatus);
            para[3] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_Order", para);
            foreach (DataRow r in dt.Rows)
            {
                _Order d = new _Order();

                d.UserAddress = Convert.ToString(r["UserAddress"]);
                d.UserContact = Convert.ToString(r["UserContact"]);
                d.Description = Convert.ToString(r["Description"]);
                d.ZipCode = Convert.ToString(r["ZipCode"]);
                d.UserEmail = Convert.ToString(r["UserEmail"]);
                d.UserGender = Convert.ToInt32(r["UserGender"]);
                d.OrderID = Convert.ToInt32(r["OrderID"]);
              
                d.OrderDate = Convert.ToString(r["OrderDate"]);
                d.UserName = Convert.ToString(r["UserName"]);
                d.OrderDate = Convert.ToString(r["OrderDate"]);
                //d.MethodID = Convert.ToInt32(r["MethodID"]);
                d.OrderStatus = Convert.ToInt32(r["OrderStatus"]);
                d.StStatus = Convert.ToString(r["StStatus"]);
               
   


                lst.Add(d);
            }
            return lst;
        }

        public static List<_Order> CountOrder()
        {
            List<_Order> lst = new List<_Order>();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Type",5);
            DataTable dt = Helper.GetDataTable("Sp_Order", para);
            foreach (DataRow r in dt.Rows)
            {
                _Order d = new _Order();
                d.Pending = Convert.ToInt32(r["Pending"]);
                d.Approved = Convert.ToInt32(r["Approved"]);
                d.Rejected = Convert.ToInt32(r["Rejected"]);
                d.Delivered = Convert.ToInt32(r["Delivered"]);
                lst.Add(d);
            }
            return lst;
        }
    }
    public class _Order
    {
        public int? OrderID { get; set; }
        public int? MethodID { get; set; }
        public int? UserID { get; set; }
        public int? Pending { get; set; }
        public int? Approved { get; set; }
        public int? Rejected { get; set; }
        public int? Delivered { get; set; }
        public int UnitPrice { get; set; }
        public int Qty { get; set; }
        public int TotalPrice { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserContact { get; set; }
        public string UserAddress { get; set; }
        public int UserGender { get; set; }
        public string OrderDate { get; set; }
        public int? OrderStatus { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
        public string StStatus { get; set; }
        public string ProductName { get; set; }
     
    }

}
