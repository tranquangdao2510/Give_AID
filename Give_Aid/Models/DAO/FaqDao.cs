using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class FaqDao
    {
        NgoEntity db = null;
        public FaqDao()
        {
            db = new NgoEntity();
        }
        public IEnumerable<Faq> GetAll()
        {
            return db.Faqs.Where(a => a.Status == true).ToList();
        }
        public IEnumerable<Faq> GetByQuestion(string search_question)
        {
            search_question = search_question ?? "";
            return db.Faqs.Where(x => x.Question.Contains(search_question)).OrderBy(x => x.Question);
        }

        public Faq Detail(int id)
        {
            return db.Faqs.Where(a => a.FaqId == id).FirstOrDefault();
        }

        public int Insert(Faq faq)
        {
            db.Faqs.Add(faq);
            faq.CreateDate = DateTime.Now;
            db.SaveChanges();
            return faq.FaqId;
        }
        public bool Update(Faq faq)
        {
            try
            {
                var FAQ = db.Faqs.Find(faq.FaqId);
                FAQ.Question = faq.Question;
                FAQ.Answered = faq.Answered;
                FAQ.UpdatedDate = DateTime.Now;
                FAQ.Status = faq.Status;
                FAQ.MetaTitle = faq.MetaTitle;
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
                var faq = db.Faqs.Find(id);
                db.Faqs.Remove(faq);
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