using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopShop.Models.Dao;
using LaptopShop.Models;
using LaptopShop.Common;
using System;

namespace LaptopShop.Controllers
{
    public class UserController : Controller
    {
        OrderDao orderDao = new OrderDao();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.username, model.password); ;
                if (result == 1)
                {
                    var user = dao.GetByName(model.username);
                    UserSingleTon.Instance.User = user;
                    var userSession = new UserLogin();
                    userSession.username = user.username;
                    userSession.ID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index","Home", new { id = 1 });
                }
                else if (result == 0)
                {
                    return RedirectToAction("Index", "Home", new { id = 2 });
                    //ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                }
            }

            return RedirectToAction("Index", "Home");
        }
        public ActionResult SignOut()
        {
            Session[CommonConstants.USER_SESSION] = null;
            UserSingleTon.Instance.User = null;
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new UserDao();
                    var user = collection["username"];
                    var pass1 = collection["password"];
                    var pass2 = collection["Confirm Password"];
                    var g = collection["gender"];
                    var result = dao.SignUp(user);
                    User userN = new User();
                    if (result == 1)
                    {
                        userN.username = user;
                        userN.password = pass1;
                        userN.firstName = collection["firstname"];
                        userN.lastName = collection["lastname"];
                        if (g.Equals("Male"))
                            userN.gender = true;
                        else
                            userN.gender = false;
                        try
                        {
                            userN.birthDate = Convert.ToDateTime(collection["birth"]);
                        }
                        catch
                        {
                            userN.birthDate = Convert.ToDateTime("1-1-1999");
                        }

                        userN.address = collection["address"];
                        userN.joinDate = DateTime.Now;
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    long id = dao.Insert(userN);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Fail");
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult ViewOrder(int? id)
        {
            if (id.HasValue)
            {
                int idConvert = (int)id;
                var model = orderDao.getListOrderForUser(idConvert);
                return View(model);
            }
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult HeaderList()
        {
            if (UserSingleTon.Instance.User != null)
            {
                ViewBag.UserName = UserSingleTon.Instance.User.lastName;
            }
            return PartialView();
        }
    }
}