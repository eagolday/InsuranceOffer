using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceOffer.Web.Models.ViewModels
{
    public class OfferDetailViewModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }

        public string Description { get; set; }
        public decimal? Price { get; set; }

        public  CompanyViewModel CompanyModel { get; set; }

        public  CustomerViewModel CustomerModel { get; set; }
    }
}