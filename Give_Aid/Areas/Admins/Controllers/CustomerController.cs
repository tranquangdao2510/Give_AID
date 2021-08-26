using Give_Aid.Common;
using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Admins/Customer
        public ActionResult Index(string searchString, int page = 1, int pageSize = 7)
        {
            var dao = new CustomerDao();
            var model = dao.GetAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {

            var dao = new CustomerDao();
            var encryptedMd5Pas = Encryptor.MD5Hash(customer.PassWord);
            customer.PassWord = encryptedMd5Pas;
            int id = dao.Insert(customer);
            if (id > 0)
            {
                SetAlert("Create Customer success", "success");
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ModelState.AddModelError("", "error");
            }

            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var adm = new CustomerDao().ViewDetail(id);
            return View(adm);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {

            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                if (!string.IsNullOrEmpty(customer.PassWord))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(customer.PassWord);
                    customer.PassWord = encryptedMd5Pas;
                }

                var result = dao.Update(customer);
                if (result)
                {
                    SetAlert("Update Customer success", "success");
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ModelState.AddModelError("", "error");
                }
            }

            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new CustomerDao();
            var result = dao.Delete(id);
            if (result)
            {
                SetAlert("Delete Customer success", "success");
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ModelState.AddModelError("", "error");
            }
            return RedirectToAction("Index");
        }

    }
}