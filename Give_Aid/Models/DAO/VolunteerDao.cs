﻿using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class VolunteerDao
    {
        private NgoEntity db = null;
        public VolunteerDao()
        {
            db = new NgoEntity();
        }
        public List<Volunteer> GetVolunteer()
        {
            return db.Volunteers.Where(v => v.Status == true).OrderBy(v => v.CreateDate).ToList();
        }
        
    }
}