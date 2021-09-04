using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Give_Aid.Models.DataAccess;
using Give_Aid.Models.DAO;
using System.Net;
using PagedList;

namespace Give_Aid.Controllers
{
    public class VolunteerController : Controller
    {
        NgoEntity db = new NgoEntity();
        public ActionResult Index(int? page)
        {
            page = page ?? 1;
            int pagesize = 8;
            var model = new VolunteerDao();
            model.GetPartners = db.Partners.ToList().Where(x => x.Status == true);
            model.GetVolunteers = db.Volunteers.ToList().Where(x => x.Status == true).ToPagedList(page.Value, pagesize);
            return View(model);
        }
    }
}