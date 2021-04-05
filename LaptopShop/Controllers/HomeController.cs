using LaptopShop.Models;
using System.Web.Mvc;

namespace LaptopShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ProductDao dao = new ProductDao();
        public ActionResult Index(int? id)
        {
            ViewBag.LaptopProducts = dao.getListProductLaptop(3);
            ViewBag.MouseProducts  = dao.getListProductMouse(3);
            ViewBag.SpeakerProducts = dao.getListProductSpeaker(3);
            ViewBag.KeyBoardProducts = dao.getListProductKeyBoard(3);
            ViewBag.CategoryProduct = new CatalogDao().getListCatalog();
            return View();
        }

        [ChildActionOnly] 
        public PartialViewResult ProductCategory()
        {
            var model = new CatalogDao().getListCatalog();
            return PartialView(model);
        }


        [ChildActionOnly]
        public PartialViewResult ban_top()
        {
            ViewBag.BrandProducts = dao.getListBrandProductLaptop();
            return PartialView();
        }
        [ChildActionOnly]
        public PartialViewResult HeaderList()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult Footer()
        {
            var model = new CatalogDao().getListCatalog();
            return PartialView(model);
        }
    }
}