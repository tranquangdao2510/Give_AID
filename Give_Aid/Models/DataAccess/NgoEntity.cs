namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NgoEntity : DbContext
    {
        public NgoEntity()
            : base("name=NgoEntity")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Comtacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Donate> Donates { get; set; }
        public virtual DbSet<Faq> Faqs { get; set; }
        public virtual DbSet<Fund> Funds { get; set; }
        public virtual DbSet<ImageGallery> ImageGalleries { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.AdminName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.BlogImage)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Phone)
                .IsUnicode(false);
            modelBuilder.Entity<Contact>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Donate>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Donate>()
                .Property(e => e.FundId)
                .IsUnicode(false);

            modelBuilder.Entity<Faq>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<Faq>()
                .Property(e => e.Answered)
                .IsUnicode(false);

            modelBuilder.Entity<Fund>()
                .Property(e => e.FundId)
                .IsUnicode(false);

            modelBuilder.Entity<Fund>()
                .Property(e => e.FundName)
                .IsUnicode(false);
            
            modelBuilder.Entity<Fund>()
                .Property(e => e.Title)
                .IsUnicode(false);
            
            modelBuilder.Entity<Fund>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Fund>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Fund>()
                .Property(e => e.FundImg)
                .IsUnicode(false);

            modelBuilder.Entity<Fund>()
                .Property(e => e.TargetAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Fund>()
                .Property(e => e.CurentAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Organization>()
                .Property(e => e.OrganizationName)
                .IsUnicode(false);

            modelBuilder.Entity<Organization>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Organization>()
                .Property(e => e.Phone)
                .IsUnicode(false);

   
            modelBuilder.Entity<Partner>()
                .Property(e => e.PartnerName)
                .IsUnicode(false);

            modelBuilder.Entity<Partner>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Partner>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Partner>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Partner>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.PaymentName)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.TagName)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.VolunteersName)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Phone)
                .IsUnicode(false);
        }
    }
}
