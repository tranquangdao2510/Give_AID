using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Give_Aid.Models.DAO
{
    public class PaymentDao
    {
        private NgoEntity db = null;

        public PaymentDao()
        {
            db = new NgoEntity();
        }
        public IEnumerable<Payment> GetAll(string name, string status, int page, int pagesize = 2)
        {
            IQueryable<Payment> model = db.Payments;
            if (!string.IsNullOrEmpty(name))
            {
                model = model.Where(x => x.PaymentName.Contains(name));
            }
            if (!string.IsNullOrEmpty(status))
            {
                var statusbool = bool.Parse(status);
                model = model.Where(x => x.Status==statusbool);
            }
            
            
            return model.OrderByDescending(x => x.CreateDate)
                .Skip((page - 1) * pagesize)
                .Take(pagesize)
               ;
        }

        public bool Insert(string strPayment)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Payment payment = serializer.Deserialize<Payment>(strPayment);
            bool status = false;
            string message = string.Empty;
            if ((payment.PaymentId == 0))
            {
                payment.CreateDate = DateTime.Now;
                db.Payments.Add(payment);
                try
                {
                    db.SaveChanges();
                    status = true;
                }
                catch (Exception ex)
                {

                    status = false;
                    message = ex.Message;

                }
            }
            else
            {
                var entity = db.Payments.Find(payment.PaymentId);
                entity.PaymentName = payment.PaymentName;
                entity.UpdatedDate = DateTime.Now;
                entity.Status = payment.Status;
                try
                {
                    db.SaveChanges();
                    status = true;
                }
                catch (Exception ex)
                {

                    status = false;
                    message = ex.Message;

                }
            }
            return 
                status= true;
        }
        public Payment Edit(int id)
        {
            return db.Payments.Where(x=>x.PaymentId == id).FirstOrDefault();
        }

        public int Delete(int id)
        {
            var payment= db.Payments.Find(id);
            db.Payments.Remove(payment);

            try
            {
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                
                return payment.PaymentId;
            }
            
           
        }
        public bool bbs()
        {
            return false;
        }
        
    }
}