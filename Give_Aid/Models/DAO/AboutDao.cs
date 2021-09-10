using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class AboutDao
    {
        NgoEntity db = null;
        public AboutDao()
        {
            db = new NgoEntity();
        }
        public IEnumerable<About> GetAll()
        {
            return db.Abouts.Where(a => a.Status == true).ToList();
        }
        public IEnumerable<About> GetByName(string search_title)
        {
            search_title = search_title ?? "";
            return db.Abouts.Where(x => x.Title.Contains(search_title)).OrderBy(x => x.CreateDate);
        }

        public About Detail(int id)
        {
            return db.Abouts.Where(a => a.AboutId == id).FirstOrDefault();
        }

        public int Insert(About about)
        {
            db.Abouts.Add(about);
            about.CreateDate = DateTime.Now;
            db.SaveChanges();
            return about.AboutId;
        }
        public bool Update(About about)
        {
            try
            {
                var ab = db.Abouts.Find(about.AboutId);
                ab.AboutImg = about.AboutImg;
                ab.Title = about.Title;
                ab.Content = about.Content;
                ab.UpdatedDate = DateTime.Now;
                ab.Status = about.Status;
                ab.MetaTitle = about.MetaTitle;
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
                var about = db.Abouts.Find(id);
                db.Abouts.Remove(about);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Volunteer> GetVolunteer()
        {
            return db.Volunteers.Where(x => x.Status == true).OrderBy(x => x.CreateDate).ToList();
        }
        public IEnumerable<Faq> GetFaq(int orderby)
        {
            return db.Faqs.Where(x => x.Status == true).OrderBy(x => x.CreateDate).Take(orderby).ToList();
        }
        public IEnumerable<Partner> GetPartner()
        {
            return db.Partners.Where(x => x.Status == true).OrderBy(x => x.CreateDate).ToList();
        }

    }
}