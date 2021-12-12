using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Models.Custom
{
    public  class DropDowns
    {
        public static List<SelectListItem> ddlCategory(int? CategoryID)
        {
            _Category cate = new _Category();
            cate.CategoryID = CategoryID;
            var lst = MD_Category.GetTable(cate);
            return lst.Select(a => new SelectListItem
                {
                Text = a.CategoryName,
                Value = Convert.ToString(a.CategoryID)
            }
                ).ToList();

        }
        public static List<SelectListItem> ddlUnit(int? UnitID)
        {
            _Unit unit = new _Unit();
            unit.UnitID = UnitID;
            List<_Unit> lst = MD_Unit.GetTable(unit);
            return lst.Select(a=>new SelectListItem
            {
                Text=a.Unit,
                Value=Convert.ToString(a.UnitID)
            }
            ).ToList();
        }
        public static List<SelectListItem> ddlSize(int? SizeID)
        {
            _Size size = new _Size();
            size.SizeID = SizeID;
            List < _Size > lst= MD_Size.GetTable(size);
            return lst.Select(a => new SelectListItem{ 
            Text=a.Size,
            Value=Convert.ToString(a.SizeID)
            }).ToList();
        }
        public static List<SelectListItem> ddlColor(int? ColorID)
        {
            _Color color = new _Color();
            color.ColorID = ColorID;
            List<_Color> lst = MD_Color.GetTable(color);
            return lst.Select(a=> new SelectListItem { 
            Text=a.Color,
            Value=Convert.ToString(a.ColorID)
            }).ToList();

        }
        
    }
}