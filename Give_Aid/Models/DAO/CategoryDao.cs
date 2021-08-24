using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class CategoryDao
    {
        NgoEntity db = null;
        public CategoryDao()
        {
            db = new NgoEntity();
        }
        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public Category Detail(int id) 
        {
            return db.Categories.Where(a => a.CategoryId == id).FirstOrDefault();
        }
        public Category GetbyName(string name)
        {
            return db.Categories.SingleOrDefault(x => x.CategoryName == name);
        }
        public int Insert(Category cate)
        {
            cate.CreateDate = DateTime.Now;
            db.Categories.Add(cate);
            db.SaveChanges();
            return cate.CategoryId;
        }
        public bool Update(Category cate)
        {
            try
            {
                var Cate = db.Categories.Find(cate.CategoryId);
                Cate.CategoryName = cate.CategoryName;
                Cate.CreateDate = cate.CreateDate;
                Cate.UpdatedDate = DateTime.Now;
                Cate.Status = cate.Status;
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