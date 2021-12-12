using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class DescriptionController : Controller
    {
        // GET: Description
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DescriptionForm()
        {
            return PartialView("PartialDescription");
        }
    }
}