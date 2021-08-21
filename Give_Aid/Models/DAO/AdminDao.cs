using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class AdminDao
    {
        NgoEntity db = null;
        public AdminDao()
        {
            db = new NgoEntity();
        }
        public long Insert(Admin entity)
        {
            db.Admins.Add(entity);
            db.SaveChanges();
            return entity.AdminId;
        }
        public Admin GetbyId(string name)
        {
            return db.Admins.SingleOrDefault(x => x.AdminName == name);
        }
        public bool Login(string name, string password)
        {
            var result = db.Admins.SingleOrDefault(x => x.AdminName == name);
            if (result == null)
            {
                return Convert.ToBoolean(0);
            }
            else
            {
                if (result.Status == false)
                {
                    return Convert.ToBoolean(-1);
                }
                else
                {
                    if (result.PassWord == password)
                    {
                        return Convert.ToBoolean(1);
                    }
                    else
                    {
                        return Convert.ToBoolean(-2);
                    }
                }
            }
        }
    }
}