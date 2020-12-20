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
        UserDao cusDao = new UserDao();
        // GET: Cart
        public ActionResult Index()
        {
            int id= UserSingleTon.Instance.User.ID > 0 ? 1 : 0;
            if (id>0)
            {
                ViewBag.SessionUser = UserSingleTon.Instance.User.ID;
            }
            var model = cartDao.getListInCart();
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckAmount(int id)
        {
            Product product = new ProductDao().getItemById(id);
            if (product.Amount < 1)
            {
                return Json("true");
            }
            return Json("false");
        }
        public ActionResult Add(int id, int quantity)
        {
            var list = cartDao.getListCart();
            Cart cart = new Cart();
            if (list.Exists(x => x.Product_Id == id))
            {
                cart = cartDao.getItemByIdProduct(id);
                cart.Quantity = cart.Quantity + 1;
                //if (new ProductDao().inStockFromProduct(id) < cart.Quantity)          // kiem tra so luong ton kho cua san pham (nen dung ajax)
                //{
                    
                //}
                cartDao.UpdateQuantity(cart);
            }
            else
            {
                cart.Product_Id = id;
                cart.Quantity = quantity;
                if (UserSingleTon.Instance.User.ID > 0)
                {
                    cart.User_Id = UserSingleTon.Instance.User.ID;
                }

                int cartId = cartDao.Insert(cart);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CheckAmountCombo(int id)
        {
            Combo combo = new ComboDao().getItemyById(id);
            if (new ComboDao().CheckAmountCombo(combo) < 1)
            {
                return Json("true");
            }
            return Json("false");
        }

        public ActionResult AddCombo(int id, int quantity)
        {
            var list = cartDao.getListCart();
            Cart cart = new Cart();
            if (list.Exists(x => x.Combo_Id == id))
            {

                cart = cartDao.getItemByIdCombo(id);
                cart.Quantity = cart.Quantity + 1;
                cartDao.UpdateQuantity(cart);
            }
            else
            {
                cart.Combo_Id = id;
                cart.Quantity = quantity;
                if (UserSingleTon.Instance.User.ID > 0)
                {
                    cart.User_Id = UserSingleTon.Instance.User.ID;
                }
                int cartId = cartDao.Insert(cart);
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateQuantity(int cartId, int quantity)
        {
            if (quantity > 0)
            {
                int newQuantity = (int)quantity;
                if (quantity > 10 /*dao.inStockFromProduct(cartId)*/)   // chua kiem tra neu gio hang la combo thi se bi loi
                {
                    ViewBag.OutOfStock = "Product's quantity is higher than amount of product";
                }
                else
                {

                    Cart cart = cartDao.getItemById(cartId);
                    cart.Quantity = newQuantity;
                    cartDao.UpdateQuantity(cart);
                    ViewBag.OutOfStock = "Success";
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Checkout()
        {
            ViewBag.CartUser = cartDao.getListInCart();
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CartDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}