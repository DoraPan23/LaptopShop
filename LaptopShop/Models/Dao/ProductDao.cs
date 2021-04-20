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
        public List<ProductFormatDao> getListAllProduct()
        {
            var query = from p in db.Product
                        join c in db.Catalog on p.Catalog_ID equals c.ID
                        join b in db.Brand on p.Brand_ID equals b.ID
                        select new
                        {
                            id = p.ID,
                            product_Name = p.Product_Name,
                            catalog_Name = c.Catalog_Name,
                            amount = p.Amount,
                            price = p.Price,
                            image = p.Image,
                            discount = p.Discount,
                            detail = p.Detail,
                            brand_Name = b.Brand_Name
                        };
            List<ProductFormatDao> list = new List<ProductFormatDao>();
            foreach (var item in query)
            {
                ProductFormatDao pd = new ProductFormatDao();
                pd.Id = item.id;
                pd.Product_Name = item.product_Name;
                pd.Catalog_Name = item.catalog_Name;
                pd.Amount = item.amount;
                pd.Price = item.price;
                pd.Image = item.image;
                pd.Discount = (float)item.discount;
                pd.Detail = item.detail;
                pd.Brand_Name = item.brand_Name;
                list.Add(pd);

            }
            return list;
        }
        public List<Product> getListProductLaptop(int quantity)
        {
            return db.Product.Where(x => x.Catalog_ID == 6).Take(quantity).ToList();
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
        public bool UpdateQuantity(Product product)
        {
            try
            {
                var updateQuantity = db.Product.Find(product.ID);
                updateQuantity.Amount = product.Amount;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Product getItemById(int id)
        {
            return db.Product.Where(x => x.ID == id).SingleOrDefault();
        }

        public List<Product> getListProductByKeyword(string keyword,int range, ref double totalRecord, int page, int pageSize)
        {
            totalRecord = db.Product.Where(x => x.Product_Name.Contains(keyword)).Count();
            var model = db.Product.Where(x => x.Product_Name.Contains(keyword)).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            
            
            if (range == 1)
            {
                totalRecord = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price<15000000).Count();
                model = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price < 15000000).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();
               
            }
            else if (range == 2)
            {
                totalRecord = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price >= 15000000 && x.Price <= 25000000).Count();
                model = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price >= 15000000 && x.Price <= 25000000).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();
               
            }
            else if (range == 3)
            {
                totalRecord = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price > 25000000).Count();
                model = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price > 25000000).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                
            }

            return model;

        }

        public List<Product> getListProductByKeyword(string keyword, int range,int idCatalog, ref double totalRecord, int page, int pageSize)
        {
            totalRecord = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Catalog_ID == idCatalog).Count();
            var model = db.Product.Where(x => x.Product_Name.Contains(keyword)&&x.Catalog_ID==idCatalog).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();


            if (range == 1)
            {
                totalRecord = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price < 15000000 && x.Catalog_ID == idCatalog).Count();
                model = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price < 15000000 && x.Catalog_ID == idCatalog).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            }
            else if (range == 2)
            {
                totalRecord = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price >= 15000000 && x.Price <= 25000000 && x.Catalog_ID == idCatalog).Count();
                model = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price >= 15000000 && x.Price <= 25000000 && x.Catalog_ID == idCatalog).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            }
            else if (range == 3)
            {
                totalRecord = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price > 25000000 && x.Catalog_ID == idCatalog).Count();
                model = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price > 25000000 && x.Catalog_ID == idCatalog).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            }

            return model;

        }

        public List<Product> getListBrandProductByKeyword(string keyword, int range, int idBrand, ref double totalRecord, int page, int pageSize)
        {
            totalRecord = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Brand_ID == idBrand).Count();
            var model = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Brand_ID == idBrand).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();


            if (range == 1)
            {
                totalRecord = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price < 15000000 && x.Brand_ID == idBrand).Count();
                model = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price < 15000000 && x.Brand_ID == idBrand).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            }
            else if (range == 2)
            {
                totalRecord = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price >= 15000000 && x.Price <= 25000000 && x.Brand_ID == idBrand).Count();
                model = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price >= 15000000 && x.Price <= 25000000 && x.Brand_ID == idBrand).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            }
            else if (range == 3)
            {
                totalRecord = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price > 25000000 && x.Brand_ID == idBrand).Count();
                model = db.Product.Where(x => x.Product_Name.Contains(keyword) && x.Price > 25000000 && x.Brand_ID == idBrand).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            }

            return model;

        }
        public List<Product> getListByBrand(int brand, ref double totalRecord, int page,int pageSize)
        {
            totalRecord = db.Product.Where(x => x.Brand_ID == brand).Count();
            var model= db.Product.Where(x => x.Brand_ID == brand).OrderByDescending(x=>x.ID).Skip((page-1)*pageSize).Take(pageSize).ToList();
            return model;
        }

        public List<Product> getListByCatalog(int catalogId, ref double totalRecord, int page, int pageSize)
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

        public float getPriceProduct(int id)
        {
            var query = db.Product.Where(x => x.ID == id).SingleOrDefault();
            float price =(float) query.Price;
            if (query.Discount.HasValue)
            {
                float discount = (float)query.Discount;
                price = price - (price * discount/100);
            }
            return price;
        }
        public float getPriceCombo(int id)
        {
            var query = db.Combo.Where(x => x.ID == id).SingleOrDefault();
            float price = (float)query.totalMoney;
            if (query.discount>0)
            {
                float discount = (float)query.discount;
                price = price - (price * discount / 100);
            }
            return price;
        }

        public long Insert(Product product)
        {
            db.Product.Add(product);
            db.SaveChanges();
            return product.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var product = db.Product.Find(id);
                db.Product.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update (Product entity)
        {
            try
            {
                var product = db.Product.Find(entity.ID);
                product.Product_Name = entity.Product_Name;
                product.Catalog_ID = entity.Catalog_ID;
                product.Amount = entity.Amount;
                product.Price = entity.Price;
                product.Image = entity.Image;
                product.Discount = entity.Discount;
                product.Detail = entity.Detail;
                product.Brand_ID = entity.Brand_ID;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}