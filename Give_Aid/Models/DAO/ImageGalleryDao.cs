using Give_Aid.Models.DataAccess;
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

        public int Create(ImageGallery entity)
        {
            entity.CreateDate = DateTime.Now;
            db.ImageGalleries.Add(entity);
            db.SaveChanges();
            return entity.ImageId;
        }

    }
}