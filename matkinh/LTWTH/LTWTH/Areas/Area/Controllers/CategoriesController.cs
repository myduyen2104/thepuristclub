using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LTWTH.Models;
namespace LTWTH.Areas.Area.Controllers
{
    public class CategoriesController : Controller
    {
        DBShopEntities database = new DBShopEntities();
        // GET: Area/Categories
        public ActionResult Index()
        {
            var categories = database.Category.ToList();
            return View(categories);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                database.Category.Add(category);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("LOI TAO MOI CATEGORY");
            }
        }
        public ActionResult Details(int id)
        {
            var category = database.Category.Where(c => c.CatID == id).FirstOrDefault();
            return View(category);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = database.Category.Where(c => c.CatID == id).FirstOrDefault();
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            database.Entry(category).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = database.Category.Where(c => c.CatID == id).FirstOrDefault();
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var category = database.Category.Where(c => c.CatID == id).FirstOrDefault();
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("khong xoa duoc do lien quan den bang khac");
            }
        }
    }
}