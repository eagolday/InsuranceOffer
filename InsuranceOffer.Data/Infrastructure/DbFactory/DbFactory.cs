
namespace InsuranceOffer.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        InsuranceOfferContext dbContext;

        public InsuranceOfferContext Init()
        {
            return dbContext ?? (dbContext = new InsuranceOfferContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
