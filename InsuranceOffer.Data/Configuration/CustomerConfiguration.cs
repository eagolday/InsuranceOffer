
using InsuranceOffer.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace InsuranceOffer.Data.Configuration
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("Customers");
            Property(c => c.UniqueIdentifierNumber).IsRequired();
            Property(c => c.PlateNumber).IsRequired();
        }
    }
}
