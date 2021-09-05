﻿using BotDetect.Web.Mvc;
using Give_Aid.Common;
using Give_Aid.Models;
using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                var result = dao.Login(model.Name, Encryptor.MD5Hash(model.Password));
                if (result == Convert.ToBoolean(1))
                {
                    var user = dao.GetbyId(model.Name);
                    var userSession = new CustomerLogin();
                    userSession.CustomerName = user.CustomerName;
                    userSession.CustomerId= user.CustomerId;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == Convert.ToBoolean(0))
                {
                    ModelState.AddModelError("", "tai khoan ko ton tai");
                }
                else if (result == Convert.ToBoolean(-1))
                {
                    ModelState.AddModelError("", "tai khoan dang bi khoa");
                }
                else if (result == Convert.ToBoolean(-2))
                {
                    ModelState.AddModelError("", "mat khau ko dung");
                }
                else
                {
                    ModelState.AddModelError("", "Vui long kiem tra tk mk");
                }
                
            }
            return View(model);
        }
        [HttpPost]
        //[CaptchaValidation("CaptchaCode", "registerCaptcha", "Wrong Captcha!")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                if (dao.CkeckCustomerName(model.CustomerName))
                {
                    ModelState.AddModelError("", "The sign-in name already exists");
                }
                else if (dao.CkeckCustomerEmail(model.Email))
                {
                    ModelState.AddModelError("", "The email already exists");
                }
                else
                {
                    var cus = new Customer();
                    cus.CustomerName = model.CustomerName;
                    cus.PassWord = Encryptor.MD5Hash(model.Password);
                    cus.Phone = model.Phone;
                    cus.Email = model.Email;
                    cus.Address = model.Address;
                    cus.CreateDate = DateTime.Now;
                    cus.Status = true;
                    var result = dao.Insert(cus);
                    if (result >0)
                    {
                        ViewBag.Success = "Successful registration";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Registration failed.");
                    }
                }
            }
            return View(model);
        }
    }
}