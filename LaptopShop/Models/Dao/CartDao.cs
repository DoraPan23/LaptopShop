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
            var queryProduct = from c in db.Cart
                        join p in db.Product on c.Product_Id equals p.ID
                        select new
                        {
                            Id=c.ID,
                            product_id=p.ID,
                            image = p.Image,
                            name = p.Product_Name,
                            price = p.Price,
                            amount=p.Amount,
                            quantity = c.Quantity,
                        };
            List<CartFormatDao> list = new List<CartFormatDao>();
            foreach(var item in queryProduct)
            {
                CartFormatDao cart = new CartFormatDao();
                cart.Cart_id = item.Id;
                cart.Product_id = item.product_id;
                cart.LinkImage = item.image;
                cart.ProductName = item.name;
                cart.Price = (double)item.price;
                cart.Quantity = (int)item.quantity;
                cart.Amount = item.amount;
                list.Add(cart);
            }
            

            var queryCombo   = from c in db.Cart
                               join cb in db.Combo on c.Combo_Id equals cb.ID
                               select new
                               {
                                   id=c.ID,
                                   combo_Id=cb.ID,
                                   //image = p.Image,
                                   name = cb.Combo_Name,
                                   price = cb.totalMoney,
                                   quantity = c.Quantity
                               };
            foreach (var item in queryCombo)
            {
                CartFormatDao cart = new CartFormatDao();
                cart.Cart_id = item.id;
                cart.Product_id = item.combo_Id;
                cart.LinkImage = "abc";                 /// sua link
                cart.ProductName = item.name;
                cart.Price = (double)item.price;
                cart.Quantity = (int)item.quantity;
                cart.Amount = 10;
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

        public Cart getItemByIdProduct(int id)
        {
            return db.Cart.Where(x => x.Product_Id == id).SingleOrDefault();
        }
        public Cart getItemByIdCombo(int id)
        {
            return db.Cart.Where(x => x.Combo_Id == id).SingleOrDefault();
        }

        public List<Cart> getListCart()
        {
            return db.Cart.ToList();
        }

        public bool Delete(int id)
        {
            try
            {
                var cart = db.Cart.Where(x=>x.ID==id).SingleOrDefault();
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