using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class PartnerDao
    {
        NgoEntity db = new NgoEntity();
        public PartnerDao()
        {
            db = new NgoEntity();
        }
        public IEnumerable<Partner>GetAll(string search_name)
        {
            search_name = search_name ?? "";
            return db.Partners.Where(x => x.PartnerName.Contains(search_name)).OrderBy(x => x.PartnerName);
        }
        public int Insert(Partner partner)
        {
            db.Partners.Add(partner);
            partner.CreateDate = DateTime.Now;
            db.SaveChanges();
            return partner.PartnerId;
        }
        public Partner Detail(int id)
        {
            return db.Partners.Where(x => x.PartnerId == id).FirstOrDefault();
        }
        public bool Update(Partner partner)
        {
            try
            {
                var pner = db.Partners.Find(partner.PartnerId);
                pner.PartnerName = partner.PartnerName;
                pner.Email = partner.Email;
                pner.Image = partner.Image;
                pner.Address = partner.Address;
                pner.Phone = partner.Phone;
                pner.UpdatedDate = DateTime.Now;
                pner.Status = partner.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var partner = db.Partners.Find(id);
                db.Partners.Remove(partner);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
