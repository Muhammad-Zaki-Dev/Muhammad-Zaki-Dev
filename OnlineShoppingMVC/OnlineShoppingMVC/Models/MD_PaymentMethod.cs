
using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_PaymentMethod
    {
        public static void Save(_PaymentMethod p)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@MethodID", p.MethodID);
            para[1] = new SqlParameter("@Method", p.Method);
            para[2] = new SqlParameter("@MethodStatus", p.MethodStatus);
            para[3] = new SqlParameter("@Type", p.MethodID==null ? ActionType.Save:ActionType.Update);

            Helper.ExecuteQuery("Sp_PaymentMethod", para);
        }
        public static List<_PaymentMethod> GetTable(_PaymentMethod p)
        {
            List<_PaymentMethod> lst = new List<_PaymentMethod>();
            SqlParameter[] Param = new SqlParameter[3];
            Param[0] = new SqlParameter("@Method", p.Method);
            Param[1] = new SqlParameter("@MethodID", p.MethodID);
            Param[2] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt= Helper.GetDataTable("Sp_PaymentMethod", Param);
            foreach (DataRow r in dt.Rows)
            {
                _PaymentMethod pay = new _PaymentMethod();
                pay.Method = Convert.ToString(r["Method"]);
                pay.Status = Convert.ToString(r["Status"]);
                pay.MethodID = Convert.ToInt32(r["MethodID"]);
                pay.MethodStatus = Convert.ToInt32(r["MethodStatus"]);
              
                lst.Add(pay);
            }
            return lst;
        }
        public static _PaymentMethod GetTable(int MethodID)
        {
            SqlParameter[] para = new SqlParameter[2];

            para[0] = new SqlParameter("@Type", ActionType.Select);
            para[1] = new SqlParameter("@MethodID", MethodID);
            DataTable dt = Helper.GetDataTable("SP_PaymentMethod", para);
            _PaymentMethod p = new _PaymentMethod();
            if (dt.Rows.Count > 0)
            {
                p.MethodID = Convert.ToInt32(dt.Rows[0]["MethodID"]);
                p.MethodStatus = Convert.ToInt32(dt.Rows[0]["MethodStatus"]);
                p.Method = Convert.ToString(dt.Rows[0]["Method"]);
            
            }
            return p;
        }
            public static void Delete(int MethodID)
        {
            SqlParameter[] para = new SqlParameter[2];

            para[0] = new SqlParameter("@Type", ActionType.Delete);
            para[1] = new SqlParameter("@MethodID", MethodID);
            Helper.ExecuteQuery("SP_PaymentMethod", para);
        }
       
    }
    public  class _PaymentMethod
    {
        public int? MethodID { get; set; }
        public string Method { get; set; }
        public string Status { get; set; }
        public int MethodStatus { get; set; }


    }
}

