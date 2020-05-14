using InsuranceOffer.Data.Configuration;
using InsuranceOffer.Model.Models;
using System.Data.Entity;

namespace InsuranceOffer.Data
{
    public class InsuranceOfferContext : DbContext
    {
        public InsuranceOfferContext() : base("InsuranceOfferConnection") { }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OfferDetail> OfferDetails { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
        }
    }
}
