using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models
{
    public class ProductDao
    {
        LaptopShopDbContext db = null;
        public ProductDao()
        {
            db = new LaptopShopDbContext();
        }
        public List<Product> getListProductLaptop(int quantity)
        {
            return db.Product.Where(x=>x.Catalog_ID==6).Take(quantity).ToList();
        }
        public List<Product> getListProductMouse(int quantity)
        {
            return db.Product.Where(x => x.Catalog_ID == 5).Take(quantity).ToList();
        }
        public List<Product> getListProductSpeaker(int quantity)
        {
            return db.Product.Where(x => x.Catalog_ID == 5).Take(quantity).ToList();
        }
        public List<Product> getListProductKeyBoard (int quantity)
        {
            return db.Product.Where(x => x.Catalog_ID == 2).Take(quantity).ToList();
        }
        public Product getDetailProduct(int id)
        {
            return db.Product.Find(id);
        }
        public List<Product> getListRelatedProduct(int id)
        {
            Product product = getDetailProduct(id);
            string productName = product.Product_Name;
            string[] data=productName.Split(new string[] { " " }, StringSplitOptions.None);
            string brandProduct = data[0];
            return db.Product.Where(x => x.Product_Name.Contains(brandProduct)).ToList();
        }
        public List<Brand> getListBrandProductLaptop()      //phuc vu cho cai ban_top
        {
            var query = from p in db.Product
                        join b in db.Brand on p.Brand_ID equals b.ID
                        where p.Catalog_ID==6
                        group new { p, b } by new { b.Brand_Name, p.Brand_ID } into pGroup
                        select new
                        {
                            BrandId=pGroup.Key.Brand_ID,
                            BrandName = pGroup.Key.Brand_Name
                        };
            List<Brand> list = new List<Brand>();
            foreach(var item in query)
            {
                Brand brand = new Brand();
                brand.ID =(int) item.BrandId;
                brand.Brand_Name = item.BrandName;
                list.Add(brand);
            }
            return list;
        }

        public List<Product> getListByBrand(int brand, ref int totalRecord, int page=1,int pageSize=2)
        {
            totalRecord = db.Product.Where(x => x.Brand_ID == brand).Count();
            var model= db.Product.Where(x => x.Brand_ID == brand && x.Catalog_ID==6).OrderByDescending(x=>x.ID).Skip((page-1)*pageSize).Take(pageSize).ToList();
            return model;
        }

        public List<Product> getListByCatalog(int catalogId, ref int totalRecord, int page = 1, int pageSize = 2)
        {
            totalRecord = db.Product.Where(x => x.Catalog_ID == catalogId).Count();
            var model= db.Product.Where(x => x.Catalog_ID == catalogId).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }

        public List<Brand> getListBrandForProduct(int catalogId)      //phuc vu cho fillter
        {
            var query = from p in db.Product
                        join b in db.Brand on p.Brand_ID equals b.ID
                        where p.Catalog_ID == catalogId
                        group new { p, b } by new { b.Brand_Name, p.Brand_ID } into pGroup
                        select new
                        {
                            BrandId = pGroup.Key.Brand_ID,
                            BrandName = pGroup.Key.Brand_Name
                        };
            List<Brand> list = new List<Brand>();
            foreach (var item in query)
            {
                Brand brand = new Brand();
                brand.ID = (int)item.BrandId;
                brand.Brand_Name = item.BrandName;
                list.Add(brand);
            }
            return list;
        }

        public string getNameById(int id)
        {
            var res = db.Brand.Where(x => x.ID == id).SingleOrDefault();
            string name = res.Brand_Name.ToString();
            return name;
        }


    }
}