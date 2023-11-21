using DEMOO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEMOO.Controllers
{
    public class HomeController : Controller
    {
        DBShopEntities db = new DBShopEntities();
        public ActionResult Index(string search)
        {
            var searchpro = db.Products.ToList();
            if (!String.IsNullOrEmpty(search))
            {
                searchpro = searchpro.Where(x => x.NamePro.Trim() == search).ToList();
            }
            return View(searchpro);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}