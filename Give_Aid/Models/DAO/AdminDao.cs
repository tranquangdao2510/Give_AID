using Give_Aid.Common;
using Give_Aid.Models.DataAccess;
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
            entity.CreatedDate = DateTime.Now;
            db.Admins.Add(entity);
            db.SaveChanges();
            return entity.AdminId;
        }

        public IEnumerable<Admin> GetAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Admin> model = db.Admins;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.AdminName.Contains(searchString)).OrderByDescending(x => x.CreatedDate);
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
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
        public List<string> getListPermision(string adminName)
        {
            var admin = db.Admins.Single(a => a.AdminName == adminName);
            var data = (from p in db.Permissions
                        join g in db.GroupAdmins on p.GroupAdminId equals g.Id
                        join r in db.Roles on p.RoleId equals r.Id
                        where g.Id == admin.GroupAdminId
                        select new
                        {
                            RoleId = p.RoleId,
                            GroupAdminId = p.GroupAdminId
                        }).AsEnumerable().Select(x => new Permission() {
                            RoleId = x.RoleId,
                            GroupAdminId = x.GroupAdminId
                       });
            return data.Select(x=>x.RoleId).ToList();
        }
        public int Login(string name, string password, bool isLoginAdmin = false)
        {
            var result = db.Admins.SingleOrDefault(x => x.AdminName == name);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupAdminId == CommonGroup.ADMIN_GROUP || result.GroupAdminId == CommonGroup.EMPLOYEES_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.PassWord == password)
                            {
                                return 1;
                            }
                            else
                            {
                                return -2;
                            }
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.PassWord == password)
                        {
                            return 1;
                        }
                        else
                        {
                            return -2;
                        }
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