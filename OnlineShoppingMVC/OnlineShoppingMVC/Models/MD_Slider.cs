using OnlineShoppingMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class MD_Slider
    {
        public static List<_Slider> GetTable(_Slider c)
        {
            List<_Slider> lst = new List<_Slider>();
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@SliderID", c.SliderID);
        
            Param[1] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_Silder", Param);
            foreach (DataRow r in dt.Rows)
            {
                _Slider v = new _Slider();
                v.SliderID = Convert.ToInt32(r["SliderID"]);
                v.SliderImage = Convert.ToString(r["SliderImage"]);
                v.Status = Convert.ToInt32(r["Status"]);
                v.StStatus = Convert.ToString(r["StStatus"]);
                lst.Add(v);
            }
            return lst;
        }
        public static _Slider GetTable(int SliderID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SliderID", SliderID);
            para[1] = new SqlParameter("@Type", ActionType.Select);
            DataTable dt = Helper.GetDataTable("Sp_Silder", para);
            _Slider p = new _Slider();
            if (dt.Rows.Count > 0)
            {
                p.SliderImage = Convert.ToString(dt.Rows[0]["SliderImage"]);
                p.SliderID = Convert.ToInt32(dt.Rows[0]["SliderID"]);
                p.Status = Convert.ToInt32(dt.Rows[0]["Status"]);

            }
            return p;
        }
        public static void Save(_Slider p)
        {

            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@SliderID", p.SliderID);
            para[1] = new SqlParameter("@SliderImage", p.SliderImage);
            para[2] = new SqlParameter("@Status", p.Status);
            para[3] = new SqlParameter("@Type", p.SliderID == null ? ActionType.Save : ActionType.Update);

            Helper.ExecuteQuery("Sp_Silder", para);

        }
        public static void Delete(int SliderID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SliderID", SliderID);
            para[1] = new SqlParameter("@Type", ActionType.Delete);
            Helper.ExecuteQuery("Sp_Silder", para);
        }
    }
    public class _Slider
    {
        public int? SliderID { get; set; }
        public string SliderImage { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public int Status { get; set; }
        public string StStatus { get; set; }

    }
}