using LaptopShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Controllers
{
    public class ProductController : Controller
    {
        ProductDao dao = new ProductDao();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetailProduct(int id)
        {
            var model = dao.getDetailProduct(id);
            ViewBag.ProductDetail = model;
            ViewBag.SpecificationProduct = model.Detail;
            ViewBag.ProductRelated = dao.getListRelatedProduct(id);
            ViewBag.BrandProducts = dao.getListBrandProductLaptop();
            return View(model);
        }

        public ActionResult Products(int? id, int page = 1, int pageSize = 12)  // xuat ra cac san pham theo brand 
        {
            if (id > 0)
            {
                int id1 = (int)id;
                var productDetail = dao.getDetailProduct(id1);
                ViewBag.DetailProduct = productDetail;
                int totalRecord = 0;
                var model = new ProductDao().getListByBrand(id1, ref totalRecord, page, pageSize);  // ref: biến sài ref nó sẽ lưu giá trị khi kết thúc hàm
                ViewBag.Products = model;
                ViewBag.BrandName = dao.getNameById(id1);
                ViewBag.BrandProducts = dao.getListBrandProductLaptop();
                ViewBag.IdBrand = id1;

                ViewBag.TotalRecord = totalRecord;  // totalRecord ở đây đã được gắn giá trị
                ViewBag.Page = page;

                if (totalRecord < 12)           //kiểm tra fill đầy trang
                {
                    pageSize = totalRecord;
                }

                int maxPage = 5;
                int totalPage = 0;
                totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
                ViewBag.TotalPage = totalPage;
                ViewBag.MaxPage = maxPage;
                ViewBag.First = 1;
                ViewBag.Last = maxPage;
                ViewBag.Next = page + 1;
                ViewBag.Prev = page - 1;
                return View(model);
            }

            return View();
        }
        
        public ActionResult FillByCatalog(int id, int page = 1, int pageSize = 12)    // xuat ra tat ca san pham theo catalog id
        {
            //lam fillter
            ViewBag.BrandForCatalog = dao.getListBrandForProduct(id);

            // lay ten danh muc
            ViewBag.CatelogyName = new CatalogDao().getNameById(id);
            ViewBag.IdCatelogy = id;

            // code phan trang
            int totalRecord = 0;
            var model = dao.getListByCatalog(id, ref totalRecord, page, pageSize);  // ref: biến sài ref nó sẽ lưu giá trị khi kết thúc hàm
            ViewBag.CategoryForProduct = model;
            ViewBag.TotalRecord = totalRecord;  // totalRecord ở đây đã được gắn giá trị
            ViewBag.Page = page;

            if (totalRecord < 12)           //kiểm tra fill đầy trang
            {
                pageSize = totalRecord;
            }

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = maxPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View();
        }
      

        [ChildActionOnly]
        public PartialViewResult Footer()
        {
            var model = new CatalogDao().getListCatalog();
            return PartialView(model);
        }
    }
}