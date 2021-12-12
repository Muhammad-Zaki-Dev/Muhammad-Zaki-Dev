using OnlineShoppingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingMVC.Controllers
{
    public class NewsController : Controller
    {
        static int? NewsID;
        // GET: News
        public ActionResult Index()
        {
            var data = MD_News.GetTable(new _News());

            return View(data);
        }
        public ActionResult SingleNews()
        {
            if (Convert.ToInt32(Request.QueryString["NewsID"])>0)
            {
                NewsID = Convert.ToInt32(Request.QueryString["NewsID"]);
            }
            return View();
        }
        public ActionResult _SingleNewss()
        {
            _News news = new _News();
            news.NewsID = NewsID;
            var data = MD_News.GetTable(news);
            return PartialView("_ViewSingle");
        }
        public ActionResult _SingleNews(int NewID)
        {
            _News news = new _News();
            news.NewsID = NewID;
            var data = MD_News.GetTable(news);
            return PartialView("_ViewsSingle");
        }
    }
}