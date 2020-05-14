using InsuranceOffer.Model.Models;
using InsuranceOffer.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.Data.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Company GetCompanyByName(string name);
    }

    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Company GetCompanyByName(string name)
        {
            var company = this.DbContext.Companies.Where(c => c.Name == name).FirstOrDefault();

            return company;
        }

        public override void Update(Company entity)
        {
            entity.UpdateDate = DateTime.Now;
            base.Update(entity);
        }
    }



}
