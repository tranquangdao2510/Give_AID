using Give_Aid.Models.DataAccess;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class SliderDao
    {
        private NgoEntity db = null;

        public SliderDao()
        {
            db = new NgoEntity();
        }

        public int Insert(Slide entity)
        {
            db.Slides.Add(entity);
            entity.CreateDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            db.SaveChanges();
            return entity.SliderId;
        }

        public IEnumerable<Slide> GetAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slides;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Description.Contains(searchString)).OrderByDescending(x => x.CreateDate);
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public bool Update(Slide slide)
        {
            try
            {
                var entity = db.Slides.Find(slide.SliderId);
                entity.Description = slide.Description;
                entity.Url = slide.Url;
                entity.DisplayOrder = slide.DisplayOrder;
                entity.Image = slide.Image;
                entity.UpdatedDate = DateTime.Now;
                entity.Status = slide.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Slide GetbyId(string name)
        {
            return db.Slides.SingleOrDefault(x => x.Description == name);
        }

        public Slide ViewDetail(int id)
        {
            return db.Slides.Where(a => a.SliderId == id).FirstOrDefault();
        }

       

        public bool Delete(int id)
        {
            try
            {
                var slide = db.Slides.Find(id);
                db.Slides.Remove(slide);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}