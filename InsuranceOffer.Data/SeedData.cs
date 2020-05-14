using InsuranceOffer.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.Data
{
    public class SeedData : DropCreateDatabaseIfModelChanges<InsuranceOfferContext>
    {
        protected override void Seed(InsuranceOfferContext context)
        {
            GetCustomers().ForEach(c => context.Customers.Add(c));
            GetCompanies().ForEach(c => context.Companies.Add(c));

            context.Commit();
        }

        private static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {
                    IsDeleted=false,
                    PlateNumber="123",
                    UniqueIdentifierNumber="89830488288",
                    SerialCode="N23",
                    SerialNumber="SN849877979",
                },

                     new Customer {
                    IsDeleted=false,
                    PlateNumber="1233",
                    UniqueIdentifierNumber="89830488000",
                    SerialCode="o111",
                    SerialNumber="SN333333",
                },
            };
        }

        private static List<Company> GetCompanies()
        {
            return new List<Company>
            {
                new Company {
                    IsDeleted=false,
                    Logo="A-logo.png",
                    Name="A Firması",
                    ServiceUrl="https://localhost:44333/offers/a",

                },

                new Company {
                    IsDeleted=false,
                     Logo="B-logo.png",
                    Name="B Firması",
                    ServiceUrl="https://localhost:44333/offers/b",
                },
                new Company {
                    IsDeleted=false,
                    Logo="C-logo.png",
                    Name="C Firması",
                    ServiceUrl="https://localhost:44333/offers/c",
                },
            };
        }

    }

}
