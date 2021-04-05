using LaptopShop.Models;
using LaptopShop.Models.Dao;
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
        ComboDao cbDao = new ComboDao();
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
            return View(model);
        }

        public ActionResult FillByBrand(int? id, int page = 1, int pageSize = 9)  // xuat ra cac san pham theo brand 
        {
            if (id > 0)
            {
                int id1 = (int)id;
                var productDetail = dao.getDetailProduct(id1);
                ViewBag.DetailProduct = productDetail;
                double totalRecord = 0;
                var model = new ProductDao().getListByBrand(id1, ref totalRecord, page, pageSize);  // ref: biến sài ref nó sẽ lưu giá trị khi kết thúc hàm
                ViewBag.FillByBrand = model;
                ViewBag.BrandName = dao.getNameById(id1);
                ViewBag.IdBrand = id1;

                ViewBag.TotalRecord = totalRecord;  // totalRecord ở đây đã được gắn giá trị
                ViewBag.Page = page;

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
        
        public ActionResult FillByCatalog(int id, int page = 1, int pageSize = 9)    // xuat ra tat ca san pham theo catalog id
        {
            //lam fillter
            
            ViewBag.BrandForCatalog = dao.getListBrandForProduct(id);

            // lay ten danh muc
            ViewBag.CatelogyName = new CatalogDao().getNameById(id);
            ViewBag.IdCatelogy = id;

            // code phan trang
            double totalRecord = 0;
            var model = dao.getListByCatalog(id, ref totalRecord, page, pageSize);  // ref: biến sài ref nó sẽ lưu giá trị khi kết thúc hàm
            ViewBag.CategoryForProduct = model;
            ViewBag.TotalRecord = totalRecord;  // totalRecord ở đây đã được gắn giá trị
            ViewBag.Page = page;

            int maxPage = 9;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling(totalRecord / pageSize);
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = maxPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View();

        }
      
        public ActionResult DetailCombo(int id)
        {
            var model = cbDao.getItemById(id);
            ViewBag.ComboProduct = model;
            return View(model);
        }

        [HttpGet]
        public ActionResult SearchInCatalog(string keyword, int? range,int id, int page = 1, int pageSize = 9)    // xuat ra tat ca san pham theo catalog id
        {

            // lay ten keyword
            ViewBag.Keyword = keyword;

            ViewBag.CatelogyName = new CatalogDao().getNameById(id);
            ViewBag.IdCatelogy = id;

            // code phan trang
            double totalRecord = 0;
            int rangeNew;
            if (!range.HasValue) { rangeNew = 0; }
            else { rangeNew = (int)range; }
            ViewBag.Range = rangeNew;
            var model = dao.getListProductByKeyword(keyword, rangeNew,id, ref totalRecord, page, pageSize);  // ref: biến sài ref nó sẽ lưu giá trị khi kết thúc hàm
            ViewBag.ProductByKeyword = model;
            ViewBag.TotalRecord = totalRecord;  // totalRecord ở đây đã được gắn giá trị
            ViewBag.Page = page;

            //if (totalRecord < 5)           //kiểm tra fill đầy trang
            //{
            //    pageSize = totalRecord;
            //}

            int maxPage = 9;
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

        [HttpGet]
        public ActionResult Search(string keyword, int? range, int page = 1, int pageSize = 9)    // xuat ra tat ca san pham theo catalog id
        {

            // lay ten keyword
            ViewBag.Keyword = keyword;
            // code phan trang
            double totalRecord = 0;
            int rangeNew;
            if (!range.HasValue) { rangeNew = 0; }
            else { rangeNew = (int)range; }
            ViewBag.Range = rangeNew;
            var model = dao.getListProductByKeyword(keyword , rangeNew, ref totalRecord, page, pageSize);  // ref: biến sài ref nó sẽ lưu giá trị khi kết thúc hàm
            ViewBag.ProductByKeyword = model;
            ViewBag.TotalRecord = totalRecord;  // totalRecord ở đây đã được gắn giá trị
            ViewBag.Page = page;

            //if (totalRecord < 5)           //kiểm tra fill đầy trang
            //{
            //    pageSize = totalRecord;
            //}

            int maxPage = 9;
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

        [HttpGet]
        public ActionResult SearchInBrand(string keyword, int? range, int id, int page = 1, int pageSize = 9)
        {

            // lay ten keyword
            ViewBag.Keyword = keyword;

            ViewBag.IdBrand = id;
            ViewBag.BrandName = dao.getNameById(id);

            // code phan trang
            double totalRecord = 0;
            int rangeNew;
            if (!range.HasValue) { rangeNew = 0; }
            else { rangeNew = (int)range; }
            ViewBag.Range = rangeNew;
            var model = dao.getListBrandProductByKeyword(keyword, rangeNew, id, ref totalRecord, page, pageSize);  // ref: biến sài ref nó sẽ lưu giá trị khi kết thúc hàm
            ViewBag.ProductByKeyword = model;
            ViewBag.TotalRecord = totalRecord;  // totalRecord ở đây đã được gắn giá trị
            ViewBag.Page = page;

            //if (totalRecord < 5)           //kiểm tra fill đầy trang
            //{
            //    pageSize = totalRecord;
            //}

            int maxPage = 9;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling(totalRecord / pageSize);
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