﻿using Give_Aid.Models.DataAccess;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Give_Aid.Models.DAO
{
    public class AdminDao
    {
        private NgoEntity db = null;

        public AdminDao()
        {
            db = new NgoEntity();
        }

        public int Insert(Admin entity)
        {
            db.Admins.Add(entity);
            db.SaveChanges();
            return entity.AdminId;
        }

        public IEnumerable<Admin> GetAllPaging(int page, int pageSize)
        {
            return db.Admins.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Update(Admin admin)
        {
            try
            {
                var adm = db.Admins.Find(admin.AdminId);
                adm.AdminName = admin.AdminName;
                adm.Email = admin.Email;
                if (!string.IsNullOrEmpty(admin.PassWord))
                {
                    adm.PassWord = admin.PassWord;
                }
                adm.Address = admin.Address;
                adm.Phone = admin.Phone;
                adm.BirthDay = admin.BirthDay;
                adm.CreatedDate = admin.CreatedDate;
                adm.UpdatedDate = DateTime.Now;
                adm.Status = admin.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Admin GetbyId(string name)
        {
            return db.Admins.SingleOrDefault(x => x.AdminName == name);
        }

        public Admin ViewDetail(int id)
        {
            return db.Admins.Where(a => a.AdminId == id).FirstOrDefault();
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

        public bool Delete(int id)
        {
            try
            {
                var admin = db.Admins.Find(id);
                db.Admins.Remove(admin);
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