using InsuranceOffer.Model.Models;
using InsuranceOffer.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.Data.Repositories
{
   public class OfferDetailRepository : RepositoryBase<OfferDetail>, IOfferDetailRepository
    {
        public OfferDetailRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

    }

    public interface IOfferDetailRepository : IRepository<OfferDetail>
    {
    }

}
