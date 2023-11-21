using DEMOO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEMOO.Areas.Areas.Controllers
{
    public class LoginAdminController : Controller
    {
        DBShopEntities db = new DBShopEntities();
        // GET: Areas/LoginAdmin
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AdminUser ad)
        {
            if ( ModelState.IsValid ) 
            {
                if (string.IsNullOrEmpty(ad.NameUser)) ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(ad.PasswordUser)) ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(ad.EmailUser)) ModelState.AddModelError(string.Empty, "Email không được để trống");
                //Kiểm tra xem có người nào đã đăng kí với tên đăng nhập này hay chưa
                var quanli = db.AdminUsers.FirstOrDefault(k =>k.EmailUser == ad.EmailUser);
                if (quanli != null) ModelState.AddModelError(string.Empty, "Email này đã được sử dụng");
                if(ModelState.IsValid ) 
                {
                    db.AdminUsers.Add(ad);
                    db.SaveChanges();   
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminUser ad)
        {
            if (!ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(ad.EmailUser)) ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(ad.PasswordUser)) ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    // tim khach hang co ten dang nhap va password hop le trong csdl
                    var quanli = db.AdminUsers.FirstOrDefault(k => k.EmailUser == ad.EmailUser && k.PasswordUser == ad.PasswordUser);
                    if (quanli != null)
                    {
                        ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công";
                        //luu vao session
                        Session["TaiKoan"] = quanli;
                        return RedirectToAction(actionName: "Index", controllerName: "Category");
                    }
                    else
                    {
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                    }
                }
            }
            return RedirectToAction(actionName: "Index", controllerName: "Category");
        }
    }
}