using DEMOO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;

namespace DEMOO.Controllers
{
    public class CustomerProductController : Controller
    {
        DBShopEntities db = new DBShopEntities();
        // GET: CustomerProduct
        public ActionResult Index(string category, string order)
        {
            var products = db.Products.ToList();
            if  (!String.IsNullOrEmpty(category))
            {
                products = products.Where(x => x.Category.Trim() == category).ToList();
            }

            if (order == "tang_dan")
            {
                products = products.OrderBy(p => p.Price).ToList();
            }
            else if (order == "giam_dan")
            {
                products = products.OrderByDescending(p => p.Price).ToList();
            }
            else
            {
                products = products.OrderByDescending(p => p.ProductID).ToList();
            }

            ViewBag.Category = category;
            ViewBag.Order = order;

            return View(products);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new
                HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}