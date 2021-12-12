
using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_OrderItem
    {

        public static List<_OrderItem> GetTable(_OrderItem items)
        {
            List<_OrderItem> lst = new List<_OrderItem>();
            SqlParameter[] para = new SqlParameter[3];
            para[0]= new SqlParameter("@OrderID", items.OrderID);
            para[1]= new SqlParameter("@OrderDetail", items.OrderDetailID);

            para[2] = new SqlParameter("@type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_OrderDetail", para);
            foreach (DataRow r in dt.Rows)
            {
                _OrderItem O = new _OrderItem();
                O.ProductID = Convert.ToInt32(r["ProductID"]);
                O.ProductName = Convert.ToString(r["ProductName"]);
                O.UnitPrice = Convert.ToInt32(r["UnitPrice"]);
                O.Qty = Convert.ToInt32(r["Qty"]);
                O.TotalPrice = Convert.ToInt32(r["TotalPrice"]);
                O.UserAddress = Convert.ToString(r["UserAddress"]);
                O.UserContact = Convert.ToString(r["UserContact"]);
                O.UserEmail = Convert.ToString(r["UserEmail"]);
                O.UserName = Convert.ToString(r["UserName"]);
                O.OrderDate = Convert.ToString(r["OrderDate"]);
                O.OrderID = Convert.ToInt32(r["OrderID"]);
             
             
                lst.Add(O);
            }
            return lst;
        }

    }
    public class _OrderItem
    {
        public int? OrderDetailID { get; set; }
        public int? OrderID { get; set; }
        public int ProductID { get; set; }
        public int Qty { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserContact { get; set; }
        public string UserAddress { get; set; }
        public string UserGender { get; set; }
        public string OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public string ProductName { get; set; }




    }







    }
