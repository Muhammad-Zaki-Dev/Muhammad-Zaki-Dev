using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.BasePage
{
    public class BaseClass: Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (Session["AdminID"] != null)
            {
                base.OnActionExecuted(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Admin/LoginIndex");
            }

        }
    }
    public class CusBaseClass : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (Session["UserID"] != null)
            {
                base.OnActionExecuted(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Customer/IndexLogin");
            }

        }
    }
}