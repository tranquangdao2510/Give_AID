using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Give_Aid.Models.DAO
{
    public class BlogClientDao
    {
        private NgoEntity db = new NgoEntity();
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Blog> BlogsNewpost { get; set; }
        public IEnumerable<Blog> BlogsPagination { get; set; }
        public IEnumerable<Tag> Tags { get; set; }

        
        public List<Blog> GetBlog()
        {
            return db.Blogs.Where(b => b.Status == true).OrderByDescending(b => b.CreateDate).ToList();
        }
    }
}