using LaptopShop.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Controllers
{
    public class CustomerController : Controller
    {
        OrderDao orderDao = new OrderDao();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewOrder(int? id)
        {
            if (id.HasValue)
            {
                int idConvert = (int)id;
                var model = orderDao.getListOrderForCustomer(idConvert);
                return View(model);
            }
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult HeaderList()
        {
            ViewBag.SessionUser = 1;
            return PartialView();
        }
    }
}