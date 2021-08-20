using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Give_AID.Models.DataModels
{
    public class NgoEntities:DbContext
    {
        public NgoEntities() : base("name=NgoConnectionString") { }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Fund> Funds { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Donate> Donates { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<ImageGallery> ImageGalleries { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Volunteers> Volunteerss { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Partner> Partners { get; set; }
    }
}