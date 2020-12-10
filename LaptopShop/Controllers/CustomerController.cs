
﻿using LaptopShop.Common;
using LaptopShop.Models;
using LaptopShop.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopShop.Models.Dao;
using LaptopShop.Models;
using LaptopShop.Common;

namespace LaptopShop.Controllers
{
    public class CustomerController : Controller
    {
        OrderDao orderDao = new OrderDao();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                var result = dao.Login(model.username, model.password); ;
                if (result == 1)
                {
                    var user = dao.GetByName(model.username);
                    UserSingleTon.Instance.User = user;
                    var userSession = new UserLogin();
                    userSession.username = user.username;
                    userSession.ID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0 && result == -2)
                {
                    ViewBag.Message = String.Format("Tài khoản hoặc mật khẩu không đúng", DateTime.Now.ToString());
                    //ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                }
                else
                {
                    ViewBag.Message = String.Format("Tài khoản hoặc mật khẩu không đúng", DateTime.Now.ToString());
                    //ModelState.AddModelError("", "Đăng nhập không đúng");
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
                    var dao = new CustomerDao();
                    var user = collection["username"];
                    var pass1 = collection["password"];
                    var pass2 = collection["Confirm Password"];
                    var g = collection["gender"];
                    var result = dao.SignUp(user, pass1, pass2);
                    Customer cus = new Customer();
                    if (result == 1)
                    {
                        cus.username = user;
                        cus.password = pass1;
                        cus.firstName = collection["firstname"];
                        cus.lastName = collection["lastname"];
                        if (g.Equals("Male"))
                            cus.gender = true;
                        else
                            cus.gender = false;
                        try
                        {
                            cus.birthDate = Convert.ToDateTime(collection["birth"]);
                        }
                        catch
                        {
                            cus.birthDate = Convert.ToDateTime("1-1-1999");
                        }

                        cus.address = collection["address"];
                        cus.joinDate = DateTime.Now;
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    long id = dao.Insert(cus);
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
                var model = orderDao.getListOrderForCustomer(idConvert);
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