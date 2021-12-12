using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_Unit
    {
        public static List<_Unit> GetTable(_Unit c)
        {
            List<_Unit> lst = new List<_Unit>();
            SqlParameter[] Param = new SqlParameter[3];
            Param[0] = new SqlParameter("@Unit", c.Unit);
            Param[1] = new SqlParameter("@UnitID", c.UnitID);
            Param[2] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_Unit", Param);
            foreach (DataRow r in dt.Rows)
            {
                _Unit v = new _Unit();
                v.UnitID = Convert.ToInt32(r["UnitID"]);
                v.Unit = Convert.ToString(r["Unit"]);
                v.Status = Convert.ToString(r["Status"]);
                v.UnitStatus = Convert.ToInt32(r["UnitStatus"]);
                lst.Add(v);
            }
            return lst;
        }
        public static _Unit GetTable(int UnitID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@UnitID", UnitID);
            para[1] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_Unit", para);
            _Unit p = new _Unit();
            if (dt.Rows.Count > 0)
            {
                p.UnitID = Convert.ToInt32(dt.Rows[0]["UnitID"]);
                p.UnitStatus = Convert.ToInt32(dt.Rows[0]["UnitStatus"]);
                p.Unit = Convert.ToString(dt.Rows[0]["Unit"]);

            }
            return p;
        }
        public static void Save(_Unit p)
        {

            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@Unit", p.Unit);
            para[1] = new SqlParameter("@UnitStatus", p.UnitStatus);
            para[2] = new SqlParameter("@UnitID", p.UnitID);
            para[3] = new SqlParameter("@Type", p.UnitID == null ? ActionType.Save : ActionType.Update);


            Helper.ExecuteQuery("Sp_Unit", para);


        }
        public static void Delete(int UnitID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@UnitID", UnitID);
            para[1] = new SqlParameter("@Type", ActionType.Delete);
            Helper.ExecuteQuery("Sp_Unit", para);
        }
    }

    public class _Unit
    {
        public int? UnitID { get; set; }
        public string Unit { get; set; }
        public string Status { get; set; }
        public int UnitStatus { get; set; }
    }
}