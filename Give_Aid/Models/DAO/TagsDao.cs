using Give_Aid.Models.DataAccess;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class TagsDao
    {
        private NgoEntity db = null;
        public TagsDao()
        {
            db = new NgoEntity();
        }
        public IEnumerable<Tag> GetAll()
        {
            return db.Tags.Where(a => a.Status == true).ToList();
        }
    }
}