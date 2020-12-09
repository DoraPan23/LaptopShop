using LaptopShop.Models;
using LaptopShop.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
            ViewBag.SessionUser = 1;

            var model = cartDao.getListInCart();
            return View(model);
        }
        public ActionResult AddProduct(int id,int quantity)
        {

            var list = cartDao.getListCart();
            Cart cart = new Cart();
            if (list.Exists(x => x.Product_Id == id))
            {
                
                cart = cartDao. getItemByIdProduct(id);
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
        public ActionResult Add(int id, int quantity)
        {
            var list = cartDao.getListCart();
            Cart cart = new Cart();
            if (list.Exists(x => x.Product_Id == id))
            {

                cart = cartDao.getItemByIdProduct(id);
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


        //public JsonResult Update(string cartModel)
        //{
        //    var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            
        //}


        [HttpPost]
        public ActionResult AddCombo(int id, int quantity)
        {
            var list = cartDao.getListCart();
            Cart cart = new Cart();
            if (list.Exists(x => x.Combo_Id == id))
            {

                cart = cartDao.getItemByIdProduct(id);
                cart.Quantity = cart.Quantity + 1;
                cartDao.UpdateQuantity(cart);
            }
            else
            {
                cart.Combo_Id = id;
                cart.Quantity = quantity;
                int cartId = cartDao.Insert(cart);
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateQuantity(int productId, int quantity)
        {
            if (quantity > 0)
            {
                int id = (int)productId;
                int newQuantity = (int)quantity;
                if (quantity > dao.inStockFromProduct(id))
                {
                    ViewBag.OutOfStock = "Product's quantity is higher than amount of product";
                }
                else
                {

                    Cart cart = cartDao.getItemByIdProduct(id);
                    if (cart == null)
                    {
                        cart = cartDao.getItemByIdCombo(id);
                    }
                    cart.Quantity = newQuantity;  
                    cartDao.UpdateQuantity(cart);
                    ViewBag.OutOfStock = "Success";
                }
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CartDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}