using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models
{
    public class CatalogDao
    {
        LaptopShopDbContext db = null;
        public CatalogDao()
        {
            db = new LaptopShopDbContext();
        }

        public List<Catalog> getListCatalog()
        {
            return db.Catalog.ToList();
        }

        public string getNameById(int id)
        {
            var res = db.Catalog.Where(x => x.ID == id).SingleOrDefault();
            string name = res.Catalog_Name.ToString();
            return name;
        }
    }
}