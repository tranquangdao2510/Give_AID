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
            
            return db.Funds.Where(x => x.FundName.Contains(search_name)).OrderBy(x=>x.CategoryId);
        }
        public string Insert(Fund fund)
        {
                db.Funds.Add(fund);
                fund.CreateDate = DateTime.Now;
                db.SaveChanges();
            return fund.FundId;
        }
        public Fund Detail(string id)
        {
            return db.Funds.Where(x=>x.FundId.Contains(id)).FirstOrDefault();
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
                F.UpdatedDate = DateTime.Now;
                F.Status = fund.Status;
                F.MetaTitle = fund.MetaTitle;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(string id)
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
        public IEnumerable<Fund> ListtopFund(int orderBy)
        {
            return db.Funds.Where(x => x.Status == true && x.DisplayOrder != null).OrderByDescending(x => x.CreateDate).Take(orderBy).ToList();
        }
        public List<Fund> ListAllFund()
        {
            return db.Funds.Where(x => x.Status == true).OrderByDescending(x => x.CreateDate).Take(6).ToList();
            
        }
        public IEnumerable<Donate> GetDonate(int orderby)
        {
            return db.Donates.Where(x => x.Status == true).OrderByDescending(x => x.Amount).Take(orderby).ToList();
        }
        public IEnumerable<Fund>  FundFeatured(int orderBy)
        {
            return db.Funds.Where(x => x.Status == true).OrderByDescending(x => x.TargetAmount).Take(orderBy).ToList();
        }
        public IEnumerable<Fund> newFund(int orderBy)
        {
            return db.Funds.Where(x => x.Status == true ).OrderByDescending(x => x.CreateDate).Take(orderBy).ToList();
        }

        public List<string> ListFundName(string keyword)
        {
            return db.Funds.Where(x => x.FundName.Contains(keyword)).Select(x => x.FundName).ToList();
        }

        public bool UpdateAmount(Fund fund)
        {
            try
            {
                var F = db.Funds.Find(fund.FundId);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<Faq> GetFaq(int orderby)
        {
            return db.Faqs.Where(x => x.Status == true).OrderBy(x => x.CreateDate).Take(orderby).ToList();
        }
        public IEnumerable<Category> GetCate(int orderby)
        {
            return db.Categories.Where(x => x.Status == true).OrderBy(x => x.CreateDate).Take(orderby).ToList();
        }

        public int CountFund()
        {
            var count = db.Funds.Count();
            return count;
        }

        public List<Fund> getNewFund()
        {
            
            return db.Funds.OrderByDescending(x=>x.CreateDate).Take(5).ToList();
        }

        public List<Fund> GetFundsId()
        {
            return db.Funds.OrderByDescending(x => x.CreateDate).ToList();
        }

        
    }
}