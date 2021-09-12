using Give_Aid.Models.DataAccess;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class CustomerDao
    {
        private NgoEntity db = null;

        public CustomerDao()
        {
            db = new NgoEntity();
        }

        public int Insert(Customer entity)
        {
            db.Customers.Add(entity);
            entity.CreateDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            db.SaveChanges();
            return entity.CustomerId;
        }

        public IEnumerable<Customer> GetAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Customer> model = db.Customers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.CustomerName.Contains(searchString)).OrderByDescending(x => x.CreateDate);
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public bool Update(Customer customer)
        {
            try
            {
                var adm = db.Customers.Find(customer.CustomerId);
                adm.CustomerName = customer.CustomerName;
                adm.Email = customer.Email;
                if (!string.IsNullOrEmpty(customer.PassWord))
                {
                    adm.PassWord = customer.PassWord;
                }
                adm.Address = customer.Address;
                adm.Phone = customer.Phone;
                adm.BirthDay = customer.BirthDay;
                adm.CreateDate = customer.CreateDate;
                adm.UpdatedDate = DateTime.Now;
                adm.Status = customer.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Customer GetbyId(string name)
        {
            return db.Customers.SingleOrDefault(x => x.CustomerName == name);
        }

        public Customer ViewDetail(int id)
        {
            return db.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
        }

        public bool Login(string name, string password)
        {
            var result = db.Customers.SingleOrDefault(x => x.CustomerName == name);
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
                var Customer = db.Customers.Find(id);
                db.Customers.Remove(Customer);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public  bool CkeckCustomerName(string customerName)
        {
            return db.Customers.Count(x => x.CustomerName == customerName) > 0;
        }

        public  bool CkeckCustomerEmail(string email)
        {
            return db.Customers.Count(x => x.Email == email) > 0;
        }

        
    }
}