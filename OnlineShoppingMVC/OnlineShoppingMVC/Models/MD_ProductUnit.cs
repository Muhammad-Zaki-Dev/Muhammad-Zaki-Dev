using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_ProductUnit
    {
        public static List<_ProductUnit> GetTable(_ProductUnit c)
        {
            List<_ProductUnit> lst = new List<_ProductUnit>();
            SqlParameter[] Param = new SqlParameter[3];
            Param[0] = new SqlParameter("@ProductUnitID", c.ProductUnitID);
            Param[1] = new SqlParameter("@ProductID", c.ProductID);
            Param[2] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp-_ProductUnit", Param);
            foreach (DataRow r in dt.Rows)
            {
                _ProductUnit v = new _ProductUnit();
                v.ProductID = Convert.ToInt32(r["ProductID"]);
                v.ProductUnitID = Convert.ToInt32(r["ProductUnitID"]);
                v.UnitID = Convert.ToInt32(r["UnitID"]);
                
                lst.Add(v);
            }
            return lst;
        }
        public static _ProductUnit GetTable(int ProductUnitID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@ProductUnitID", ProductUnitID);
            para[1] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_ProductUnit", para);
            _ProductUnit p = new _ProductUnit();
            if (dt.Rows.Count > 0)
            {
                p.ProductUnitID = Convert.ToInt32(dt.Rows[0]["ProductUnitID"]);
                p.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                p.UnitID = Convert.ToInt32(dt.Rows[0]["UnitID"]);
                

            }
            return p;
        }
        public static void Save(_ProductUnit p)
        {

            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@UnitID", p.UnitID);
            para[1] = new SqlParameter("@ProductID", p.ProductID);
            para[2] = new SqlParameter("@ProductUnitID", p.ProductUnitID);
            para[3] = new SqlParameter("@Type", p.ProductUnitID == null ? ActionType.Save : ActionType.Update);


            Helper.ExecuteQuery("Sp_ProductUnit", para);


        }
        public static void Delete(int ProductUnitID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@ProductUnitID", ProductUnitID);
            para[1] = new SqlParameter("@Type", ActionType.Delete);
            Helper.ExecuteQuery("Sp_ProductUnit", para);
        }
    }
    public class _ProductUnit
    {
        public int UnitID { get; set; }
        public int? ProductUnitID { get; set; }
        public int ProductID { get; set; }


    }
}