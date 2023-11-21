using DEMOO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DEMOO.Areas.Areas.Controllers
{
    public class CategoryController : Controller
    {
        DBShopEntities db = new DBShopEntities();
        // GET: Areas/Category
        public ActionResult Index()
        {
            var category = db.Categories.ToList();
            return View(category);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category categories)
        {
            try
            {
                db.Categories.Add(categories);
                db.SaveChanges();
                return RedirectToAction("INDEX");
            }
            catch
            {
                return Content("Error");
            }
        }
        public ActionResult Details(int id)
        {
            var category = db.Categories.Where(c => c.Id == id).FirstOrDefault();
            return View(category);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = db.Categories.Where(c => c.Id == id).FirstOrDefault();
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = db.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var category = db.Categories.Where(c => c.Id == id).FirstOrDefault();
                if (category == null)
                {
                    return HttpNotFound();
                }
                db.Categories.Remove(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Error");
            }

        }
    }
}