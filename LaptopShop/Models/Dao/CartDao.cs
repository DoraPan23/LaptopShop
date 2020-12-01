using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models.Dao
{
    public class CartDao
    {
        LaptopShopDbContext db = null;
        public CartDao()
        {
            db = new LaptopShopDbContext();
        }
        public List<CartFormatDao> getListInCart()
        {
            var query = from c in db.Cart
                        join p in db.Product on c.Product_Id equals p.ID
                        select new
                        {
                            product_id=p.ID,
                            image = p.Image,
                            name = p.Product_Name,
                            price = p.Price,
                            quantity = c.Quantity,
                        };
            List<CartFormatDao> list = new List<CartFormatDao>();
            foreach(var item in query)
            {
                CartFormatDao cart = new CartFormatDao();
                cart.Product_id = item.product_id;
                cart.LinkImage = item.image;
                cart.ProductName = item.name;
                cart.Price = item.price;
                cart.Quantity = item.quantity;
                list.Add(cart);
            }
            return list;
        }

        public int Insert (Cart cart)
        {
            db.Cart.Add(cart);
            db.SaveChanges();
            return cart.ID;
        }
        public bool UpdateQuantity(Cart cart)
        {
            try
            {
                var updateQuantity = db.Cart.Find(cart.ID);
                updateQuantity.ID = cart.ID;
                updateQuantity.Product_Id = cart.Product_Id;
                updateQuantity.Quantity = cart.Quantity;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Cart getItemById(int id)
        {
            return db.Cart.Where(x => x.Product_Id == id).SingleOrDefault();
        }

        public List<Cart> getListCart()
        {
            return db.Cart.ToList();
        }

        public bool Delete(int id)
        {
            try
            {
                var cart = db.Cart.Where(x=>x.Product_Id==id).SingleOrDefault();
                db.Cart.Remove(cart);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}