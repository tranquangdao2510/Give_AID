using Give_Aid.Models.DataAccess;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class DonateDao
    {
        private NgoEntity db = null;

        public DonateDao()
        {
            db = new NgoEntity();
        }
       

        public int Insert(Donate entity)
        {
            db.Donates.Add(entity);
            entity.CreateDate = DateTime.Now;
            db.SaveChanges();
            return entity.DonateId;
        }

        public IEnumerable<Donate> GetAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Donate> model = db.Donates;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Customer.CustomerName.Contains(searchString)).OrderByDescending(x => x.CreateDate);
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        //public bool Update(Donate Donate)
        //{
        //    try
        //    {
        //        var adm = db.Donates.Find(Donate.AdminId);
        //        adm.AdminName = Donate.AdminName;
        //        adm.Email = Donate.Email;
        //        if (!string.IsNullOrEmpty(Donate.PassWord))
        //        {
        //            adm.PassWord = Donate.PassWord;
        //        }
        //        adm.Address = Donate.Address;
        //        adm.Phone = Donate.Phone;
        //        adm.BirthDay = Donate.BirthDay;
        //        adm.CreatedDate = Donate.CreatedDate;
        //        adm.UpdatedDate = DateTime.Now;
        //        adm.Status = Donate.Status;
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public Donate GetbyId(string name)
        //{
        //    return db.Donates.SingleOrDefault(x => x.AdminName == name);
        //}

        public Donate ViewDetail(int id)
        {
            return db.Donates.Where(a => a.DonateId == id).FirstOrDefault();
        }
        public bool ChangeStatus(int id)
        {
            var donate = db.Donates.Find(id);
            donate.Status = !donate.Status;

            var funddao = new FundDao();
            var fundamount = funddao.Detail(donate.FundId);
            fundamount.CurentAmount += donate.Amount;
            funddao.UpdateAmount(fundamount);
            db.SaveChanges();
            return donate.Status;
        }
    }
}
