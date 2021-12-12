
using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_Size
    {
        public static List<_Size> GetTable(_Size c)
        {
            List<_Size> lst = new List<_Size>();
            SqlParameter[] Param = new SqlParameter[3];
            Param[0] = new SqlParameter("@Size", c.Size);
            Param[1] = new SqlParameter("@SizeID", c.SizeID);
            Param[2] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt= Helper.GetDataTable("Sp_Size", Param);
            foreach (DataRow r in dt.Rows)
            {
                _Size v = new _Size();
                v.SizeID = Convert.ToInt32(r["SizeID"]);
                v.Size = Convert.ToString(r["Size"]);
                v.Status = Convert.ToString(r["Status"]);
                v.SizeStatus = Convert.ToInt32(r["SizeStatus"]);
                lst.Add(v);
            }
            return lst;
        }
        public static _Size GetTable(int SizeID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SizeID", SizeID);
            para[1] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_Size", para);
            _Size p = new _Size();
            if (dt.Rows.Count > 0)
            {
                p.Size = Convert.ToString(dt.Rows[0]["Size"]);
                p.SizeID = Convert.ToInt32(dt.Rows[0]["SizeID"]);
                p.SizeStatus = Convert.ToInt32(dt.Rows[0]["SizeStatus"]);

            }
            return p;
        }
        public static void Save(_Size p)
        {

            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@SizeID", p.SizeID);
            para[1] = new SqlParameter("@Size", p.Size);
            para[2] = new SqlParameter("@SizeStatus", p.SizeStatus);
            para[3] = new SqlParameter("@Type", p.SizeID == null ? ActionType.Save : ActionType.Update);

            Helper.ExecuteQuery("Sp_Size", para);

        }
        public static void Delete(int SizeID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SizeID", SizeID);
            para[1] = new SqlParameter("@Type", ActionType.Delete);
            Helper.ExecuteQuery("Sp_Size", para);
        }
    }
    public class _Size
    {
        public int? SizeID { get; set; }
        public string Size { get; set; }
        public string Status { get; set; }
        public int SizeStatus { get; set; }
    }

}
