using Give_Aid.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admins/Home
        public ActionResult Dashboard()
        {
            var daoOrganization = new OrganizationDao();
            ViewBag.CountOrg = daoOrganization.CountOrganization();
            var daoCUstomer= new CustomerDao();
            ViewBag.CountCus = daoCUstomer.Countcustomer();
            var daoFund = new FundDao();
            ViewBag.CountFud = daoFund.CountFund();
            var daovlo = new VolunteerDao();
            ViewBag.CountVlo = daovlo.CountVolunteer();
            var daoDont = new DonateDao();
            ViewBag.ListDonate = daoDont.getAll();
           
            ViewBag.ListFund = daoFund.getNewFund();
            return View();
        }
        
    }
}