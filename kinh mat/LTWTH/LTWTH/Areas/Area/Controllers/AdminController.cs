using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWTH.Models;
namespace LTWTH.Areas.Area.Controllers
{
    public class AdminController : Controller
    { 
        DBShopEntities datatase = new DBShopEntities();
        // GET: Area/Admin
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
                if (string.IsNullOrEmpty(cust.PassCus)) ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(cust.EmailCus)) ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(cust.AddressCus)) ModelState.AddModelError(string.Empty, "Địa chỉ không được để trống");
                //Kiểm tra xem có người nào đã đăng kí với tên đăng nhập này hay chưa
                var khachhang = datatase.Customer.FirstOrDefault(k => k.NameCus == cust.NameCus);
                if (khachhang != null) ModelState.AddModelError(string.Empty, "Đã có người đăng kí tên này");
                if (ModelState.IsValid)
                {
                    datatase.Customer.Add(cust);
                    datatase.SaveChanges();

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
                if (string.IsNullOrEmpty(cust.NameCus)) ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(cust.PassCus)) ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    // tim khach hang co ten dang nhap va password hop le trong csdl
                    var khachhang = datatase.Customer.FirstOrDefault(k => k.NameCus == cust.NameCus && k.PassCus == cust.PassCus);
                    if (khachhang != null)
                    {
                        ViewBag.ThongBao = " chuc mung ban dang nhap thanh cong";
                        //luu vao session
                        Session["TaiKoan"] = khachhang;
                        return RedirectToAction("Index", "Categories");
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