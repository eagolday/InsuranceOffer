using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceOffer.Web.Models.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string ServiceUrl { get; set; }
        public  List<OfferDetailViewModel> OfferDetailModels { get; set; }
    }
}