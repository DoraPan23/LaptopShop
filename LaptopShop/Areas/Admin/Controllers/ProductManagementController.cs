using LaptopShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Areas.Admin.Controllers
{
    public class ProductManagementController : Controller
    {
        // GET: Admin/ProductManagement
        ProductDao dao = new ProductDao();
        public ActionResult Index()
        {
            var model = dao.getListAllProduct();
            return View(model);
        }
    }
}