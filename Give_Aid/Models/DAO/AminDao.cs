using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class AminDao
    {
        NgoEntity db = null;
        public AminDao()
        {
            db = new NgoEntity();
        }
        public long Insert(Admin entity)
        {
            db.Admins.Add(entity);
            db.SaveChanges();
            return entity.AdminId;
        }
        public bool Login(string name, string password)
        {
            var result = db.Admins.Count(x => x.AdminName == name && x.PassWord == password);
            if (result >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}