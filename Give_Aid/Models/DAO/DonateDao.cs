﻿using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class DonateDao
    {
        private NgoEntity db = null;

        public DonateDao()
        {
            db = new NgoEntity();
        }
       

        public int Insert(Donate entity)
        {
            db.Donates.Add(entity);
            entity.CreateDate = DateTime.Now;
            db.SaveChanges();
            return entity.DonateId;
        }

        //public IEnumerable<Donate> GetAllPaging(string searchString, int page, int pageSize)
        //{
        //    IQueryable<Donate> model = db.Donates;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        model = model.Where(x => x.AdminName.Contains(searchString)).OrderByDescending(x => x.CreatedDate);
        //    }
        //    return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        //}

        //public bool Update(Donate Donate)
        //{
        //    try
        //    {
        //        var adm = db.Donates.Find(Donate.AdminId);
        //        adm.AdminName = Donate.AdminName;
        //        adm.Email = Donate.Email;
        //        if (!string.IsNullOrEmpty(Donate.PassWord))
        //        {
        //            adm.PassWord = Donate.PassWord;
        //        }
        //        adm.Address = Donate.Address;
        //        adm.Phone = Donate.Phone;
        //        adm.BirthDay = Donate.BirthDay;
        //        adm.CreatedDate = Donate.CreatedDate;
        //        adm.UpdatedDate = DateTime.Now;
        //        adm.Status = Donate.Status;
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public Donate GetbyId(string name)
        //{
        //    return db.Donates.SingleOrDefault(x => x.AdminName == name);
        //}

        public Donate ViewDetail(int id)
        {
            return db.Donates.Where(a => a.DonateId == id).FirstOrDefault();
        }

        //public bool Login(string name, string password)
        //{
        //    var result = db.Donates.SingleOrDefault(x => x.AdminName == name);
        //    if (result == null)
        //    {
        //        return Convert.ToBoolean(0);
        //    }
        //    else
        //    {
        //        if (result.Status == false)
        //        {
        //            return Convert.ToBoolean(-1);
        //        }
        //        else
        //        {
        //            if (result.PassWord == password)
        //            {
        //                return Convert.ToBoolean(1);
        //            }
        //            else
        //            {
        //                return Convert.ToBoolean(-2);
        //            }
        //        }
        //    }
        //}

        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        var Donate = db.Donates.Find(id);
        //        db.Donates.Remove(Donate);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
    }
}