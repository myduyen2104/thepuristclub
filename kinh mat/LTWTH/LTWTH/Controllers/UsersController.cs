using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWTH.Models;

namespace LTWTH.Controllers
{
    public class UsersController : Controller
    {
        private DBShopEntities database = new DBShopEntities();
        // GET: Users
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
                if (string.IsNullOrEmpty(cust.PassCus))ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(cust.EmailCus)) ModelState.AddModelError(string.Empty, "Email không được để trống");
                //Kiểm tra xem có người nào đã đăng kí với tên đăng nhập này hay chưa
                var khachhang = database.Customer.FirstOrDefault(k => k.EmailCus == cust.EmailCus);
                if (khachhang != null)ModelState.AddModelError(string.Empty, "Đã có người đăng kí tên này");
                if (ModelState.IsValid)
                {
                    database.Customer.Add(cust);
                    database.SaveChanges();

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
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cust.EmailCus)) ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(cust.PassCus)) ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    // tim khach hang co ten dang nhap va password hop le trong csdl
                    var khachhang = database.Customer.FirstOrDefault(k => k.EmailCus == cust.EmailCus && k.PassCus == cust.PassCus);
                    if (khachhang != null)
                    {
                        ViewBag.ThongBao = " chuc mung ban dang nhap thanh cong";
                        //luu vao session
                        Session["TaiKoan"] = khachhang;
                        return RedirectToAction("Index","Categories");
                    }
                    else
                    {
                        ViewBag.ThongBao = " ten dang nhap hoac mat khau khong dung";
                    }
                }
            }
            return View("Login");
        }
    }
}
