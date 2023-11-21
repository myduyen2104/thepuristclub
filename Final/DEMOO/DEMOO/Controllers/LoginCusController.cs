using DEMOO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEMOO.Controllers
{
    public class LoginCusController : Controller
    {
        DBShopEntities db=new DBShopEntities();
        // GET: LoginCus

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cust.NameCus)) ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(cust.PassWordCus)) ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(cust.EmailCus)) ModelState.AddModelError(string.Empty, "Email không được để trống");
                //Kiểm tra xem có người nào đã đăng kí với tên đăng nhập này hay chưa
                var KhachHang = db.Customers.FirstOrDefault(k => k.EmailCus == cust.EmailCus);
                if (KhachHang != null) ModelState.AddModelError(string.Empty, "Email này đã được sử dụng");
                if (ModelState.IsValid)
                {
                    db.Customers.Add(cust);
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
        public ActionResult Login(Customer cust)
        {
            if (!ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cust.EmailCus)) ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(cust.PassWordCus)) ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    // tim khach hang co ten dang nhap va password hop le trong csdl
                    var khachhang = db.Customers.FirstOrDefault(k => k.EmailCus == cust.EmailCus && k.PassWordCus == cust.PassWordCus);
                    if (khachhang != null)
                    {
                        ViewBag.ThongBao = "Chúc mừng bạn đã đăng nhập thành công";
                        //luu vao session
                        Session["TaiKoan"] = khachhang;
                    }
                    else
                    {
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                    }
                }
            }
            return View();
        }
    }
}