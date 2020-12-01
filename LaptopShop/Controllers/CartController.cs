using LaptopShop.Models;
using LaptopShop.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Controllers
{
    public class CartController : Controller
    {
        public const string CartSession = "CartSession";
        ProductDao dao = new ProductDao();
        CartDao cartDao = new CartDao();
        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.BrandProducts = dao.getListBrandProductLaptop();
            //var cart = Session[CartSession];
            //var list = new List<CartItem>();
            //if (cart != null)
            //{
            //    list = (List<CartItem>)cart;
            //}
            //return View(list);

            var model = cartDao.getListInCart();
            return View(model);
        }
        public ActionResult AddProduct(int id,int quantity)
        {
            //var product = new ProductDao().getDetailProduct(id);
            //var cart = Session[CartSession];
            //if (cart != null)
            //{
            //    var list = (List<CartItem>)cart;
            //    if (list.Exists(x => x.product.ID == id))
            //    {
            //        foreach (var item in list)
            //        {
            //            if (item.product.ID == id)
            //            {
            //                item.quantity += quantity;
            //            }

            //        }
            //    }

            //    else
            //    {
            //        var item = new CartItem();
            //        item.product = product;
            //        item.quantity = quantity;
            //        list = new List<CartItem>();
            //        list.Add(item);

            //        Session[CartSession] = list;
            //    }
            //}
            //else
            //{
            //    var item = new CartItem();
            //    item.product = product;
            //    item.quantity = quantity;
            //    var list = new List<CartItem>();
            //    list.Add(item);

            //    Session[CartSession] = list;
            //}

            var list = cartDao.getListCart();
            Cart cart = new Cart();
            if (list.Exists(x => x.Product_Id == id))
            {
                
                cart = cartDao.getItemById(id);
                cart.Quantity = cart.Quantity + 1;
                cartDao.UpdateQuantity(cart);
            }
            else
            {
                cart.Product_Id = id;
                cart.Quantity = quantity;
                int cartId = cartDao.Insert(cart);
            }
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        public void Add(int id, int quantity)
        {
            var list = cartDao.getListCart();
            Cart cart = new Cart();
            if (list.Exists(x => x.Product_Id == id))
            {

                cart = cartDao.getItemById(id);
                cart.Quantity = cart.Quantity + 1;
                cartDao.UpdateQuantity(cart);
            }
            else
            {
                cart.Product_Id = id;
                cart.Quantity = quantity;
                int cartId = cartDao.Insert(cart);
            }
            //return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CartDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}