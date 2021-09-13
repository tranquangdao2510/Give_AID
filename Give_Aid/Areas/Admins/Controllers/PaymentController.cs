using Give_Aid.Common;
using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class PaymentController : BaseController
    {
        //NgoEntity db = new NgoEntity();
        // GET: Admins/Payment

        [HasPermission(RoleId = "VIEW")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoadData(string name, string status, int page, int pagesize = 10)
        {

            var dao = new PaymentDao();
            var model = dao.GetAll(name, status,page,pagesize);
            
            return Json(new
            {
                data = model,
                total = dao.totalRow,
                status = true
            },JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveData(string strPayment)
        {


            return Json(new
            {
                status = true,
                data = new PaymentDao().Insert(strPayment)

            });
        }

        [HttpGet]
        [HasPermission(RoleId = "EDIT")]
        public JsonResult Edit(int id)
        {
            var dao = new PaymentDao();
            var payment = dao.Edit(id);
            //var payment = db.Payments.Find(id);
            return Json(new
            {
                data = payment,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [HasPermission(RoleId = "DELETE")]
        public JsonResult Delete(int id)
        {
            
            return Json(new
            {
                data=new PaymentDao().Delete(id),
                status = true
            });
        }

    }
}