using LaptopShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ProductDao dao = new ProductDao();
        public ActionResult Index()
        {
            ViewBag.LaptopProducts = dao.getListProductLaptop(3);
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new CatalogDao().getListCatalog();
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult Footer()
        {
            var model = new CatalogDao().getListCatalog();
            return PartialView(model);
        }
    }
}