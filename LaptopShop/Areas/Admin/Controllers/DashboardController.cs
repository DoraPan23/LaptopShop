using LaptopShop.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        
        public ActionResult Index(int? year)
        {
            if (UserSingleTon.Instance.User.Role_ID == 3 || UserSingleTon.Instance.User.Role_ID == 0)        // kiem tra session, neu chua dang nhap la id = 0
            {
                return RedirectToAction("Index", "../Home");
            }
            ViewBag.NameUserBuyMost = new OrderDao().getCustomerBuyMost();
            ViewBag.NameProductBuyMost = new OrderDao().getProductBuyMost();
            ViewBag.NameComboBuyMost = new OrderDao().getComboBuyMost();
            
            if (year > 0)
            {
                int _year = (int)year;
                ViewBag.ListRevenue = new OrderDao().getRevenueByYear(_year);
                ViewBag.RevenueOfYear = _year;
            }
            else
            {
                ViewBag.ListRevenue = new OrderDao().getRevenueByYear(DateTime.Now.Year);
                ViewBag.RevenueOfYear = DateTime.Now.Year;
            }
            
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult _LayoutAdmin()     // tham khao headerlist de lay ten admin
        {
            if (UserSingleTon.Instance.User != null)
            {
                ViewBag.UserName = UserSingleTon.Instance.User.lastName;
            }
            return PartialView();
        }
    }
}