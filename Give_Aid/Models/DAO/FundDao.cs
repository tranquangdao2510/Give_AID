using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Models.DAO
{
    public class FundDao
    {
        NgoEntity db = new NgoEntity();
        public FundDao()
        {
            db = new NgoEntity();
        }
        public IEnumerable<Fund> GetAll(string search_name)
        {
            search_name = search_name ?? "";
            return db.Funds.Where(x => x.FundName.Contains(search_name)).OrderBy(x=>x.FundName);
        }
        public int Insert(Fund fund)
        {

            db.Funds.Add(fund);
            db.SaveChanges();
            return fund.FundId;
        }
        public Fund Detail(int id)
        {
            return db.Funds.Where(x=>x.FundId == id).FirstOrDefault();
        }

        public bool Update(Fund fund)
        {
            try
            {
                var F = db.Funds.Find(fund.FundId);
                F.FundName = fund.FundName;
                F.Description = fund.Description;
                F.Content = fund.Content;
                F.FundImg = fund.FundImg;
                F.TargetAmount = fund.TargetAmount;
                F.CurentAmount = fund.CurentAmount;
                F.CategoryId = fund.CategoryId;
                F.OrganizationId = fund.OrganizationId;
                F.CreateDate = fund.CreateDate;
                F.UpdatedDate = DateTime.Now;
                F.Status = fund.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var F = db.Funds.Find(id);
                db.Funds.Remove(F);
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