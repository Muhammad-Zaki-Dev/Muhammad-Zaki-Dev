
using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_Color
    {
        public static List<_Color> GetTable(_Color c)
        {
            List<_Color> lst = new List<_Color>();
            SqlParameter[] Param = new SqlParameter[3];
            Param[0] = new SqlParameter("@Color", c.Color);
            Param[1] = new SqlParameter("@ColorID", c.ColorID);
            Param[2] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt=  Helper.GetDataTable("Sp_Color", Param);
            foreach (DataRow r in dt.Rows)
            {
                _Color v = new _Color();
                v.ColorID = Convert.ToInt32(r["ColorID"]);
                v.Color = Convert.ToString(r["Color"]);
                v.Status = Convert.ToString(r["Status"]);
                v.ColorStatus = Convert.ToInt32(r["ColorStatus"]);
                lst.Add(v);
            }
            return lst;
        }
        public static _Color GetTable(int ColorID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@ColorID", ColorID);
            para[1] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_Color", para);
            _Color p = new _Color();
            if (dt.Rows.Count > 0)
            {
                p.ColorID = Convert.ToInt32(dt.Rows[0]["ColorID"]);
                p.ColorStatus = Convert.ToInt32(dt.Rows[0]["ColorStatus"]);
                p.Color = dt.Rows[0]["Color"].ToString();

            }
            return p;
        }
        public static void Save(_Color p)
        {

            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@Color", p.Color);
            para[1] = new SqlParameter("@ColorStatus", p.ColorStatus);
            para[2] = new SqlParameter("@ColorID", p.ColorID);
            para[3] = new SqlParameter("@Type", p.ColorID==null ? ActionType.Save:ActionType.Update);
          

            Helper.ExecuteQuery("Sp_Color", para);


        }
        public static void Delete(int ColorID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@ColorID", ColorID);
            para[1] = new SqlParameter("@Type", ActionType.Delete);
            Helper.ExecuteQuery("Sp_Color", para);
        }
    }
    public class _Color
    {
        public int? ColorID { get; set; }
        public string Color { get; set; }
        public string Status { get; set; }
        public int ColorStatus { get; set; }

    }
}