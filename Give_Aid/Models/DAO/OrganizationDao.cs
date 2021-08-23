using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class OrganizationDao
    {
        NgoEntity db = new NgoEntity();
        public OrganizationDao()
        {
            db = new NgoEntity();
        }
        public IEnumerable<Organization> GetAll()
        {
            return db.Organizations;
        }
        public int Insert (Organization organization)
        {
            db.Organizations.Add(organization);
            db.SaveChanges();
            return organization.OrganizationId;
        }

        public Organization Detail(int id)
        {
            return db.Organizations.Where(a => a.OrganizationId == id).FirstOrDefault();
        }

        public bool Update(Organization organization)
        {
            try
            {
                var Org = db.Organizations.Find(organization.OrganizationId);
                Org.OrganizationName = organization.OrganizationName;
                Org.Address = organization.Address;
                Org.Phone = organization.Phone;
                Org.CreatedDate = organization.CreatedDate;
                Org.UpdatedDate = DateTime.Now;
                Org.Status = organization.Status;
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