using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
          
            _ViewModel view = new _ViewModel();
          view=  ViewModel.GetViewModel();
            return View(view);
        }
    }
}