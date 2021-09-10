using Give_Aid.Models.DataAccess;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class ImageGalleryDao
    {
        private NgoEntity db = null;
        public ImageGalleryDao()
        {
            db = new NgoEntity();
        }

        public int Insert(ImageGallery entity)
        {
            entity.CreateDate = DateTime.Now;
            db.ImageGalleries.Add(entity);
            db.SaveChanges();
            return entity.ImageId;
        }

        public IEnumerable<ImageGallery> GetAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ImageGallery> model = db.ImageGalleries;
            if (!string.IsNullOrEmpty(searchString))
            {
                //model = model.Where(x => x..Contains(searchString)).OrderByDescending(x => x.CreateDate);
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public bool Update(ImageGallery image)
        {
            try
            {
                var entity = db.ImageGalleries.Find(image.ImageId);
              
                entity.DisplayOrder = image.DisplayOrder;
                entity.Image = image.Image;
                entity.UpdatedDate = DateTime.Now;
                entity.Status = image.Status;
                entity.MetaTitle = image.MetaTitle;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ImageGallery GetbyId(string name)
        {
            return db.ImageGalleries.SingleOrDefault(x => x.Name == name);
        }

        public ImageGallery ViewDetail(int id)
        {
            return db.ImageGalleries.Where(a => a.ImageId == id).FirstOrDefault();
        }



        public bool Delete(int id)
        {
            try
            {
                var image = db.ImageGalleries.Find(id);
                db.ImageGalleries.Remove(image);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public void UpdateImages(int id, string images)
        {
            var imageGallery = db.ImageGalleries.Find(id);
            imageGallery.MoreImage = images;
            db.SaveChanges();
        }
        public List<ImageGallery> GetImageGallery()
        {
            return db.ImageGalleries.Where(b => b.Status == true).OrderByDescending(b => b.CreateDate).Take(6).ToList();
        }
    }
}