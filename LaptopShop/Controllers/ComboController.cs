using LaptopShop.Models;
using LaptopShop.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Controllers
{
    public class ComboController : Controller
    {
        // GET: Combo
        ComboDao cbDao = new ComboDao();
        ProductDao dao = new ProductDao();
        public ActionResult Index()
        {
            var model = cbDao.getListCombo();
            return View(model);
        }
    }
}