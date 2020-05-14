using InsuranceOffer.Service.Models.Request;
using InsuranceOffer.Service.Models.Response;
using InsuranceOffer.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InsuranceOffer.WebAPI.Controllers
{
    [Route("offers")]
    public class OffersController : ApiController
    {
        private readonly ICompanyService _companyService;
        public OffersController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Route("offers/a")]
        public OfferModel GetACompanyOffer(CustomerModel customer)
        {
            var company = _companyService.GetCompanies().ElementAt(0);

            int rndPrice = new Random().Next(100, 600);
            var offer = new OfferModel()
            {
                CompanyId = company.Id,
                CompanyLogo = company.Logo,
                CompanyName = company.Name,
                Description = "A Firması Teklif Tutarı",
                PlateNumber = customer.PlateNumber,
                Price = 300 + rndPrice
            };
            return offer;
        }

        [HttpPost]
        [Route("offers/b")]
        public OfferModel GetBCompanyOffer(CustomerModel customer)
        {
            var company = _companyService.GetCompanies().ElementAt(1);

            int rndPrice = new Random().Next(100, 600);
            var offer = new OfferModel()
            {
                CompanyId = company.Id,
                CompanyLogo = company.Logo,
                CompanyName = company.Name,
                Description = "B Firması Teklif Tutarı",
                PlateNumber = customer.PlateNumber,
                Price = 400 + rndPrice
            };
            return offer;
        }

        [HttpPost]
        [Route("offers/c")]
        public OfferModel GetCCompanyOffer(CustomerModel customer)
        {
            var company = _companyService.GetCompanies().ElementAt(2);

            int rndPrice = new Random().Next(100, 600);
            var offer = new OfferModel()
            {
                CompanyId = company.Id,
                CompanyLogo = company.Logo,
                CompanyName = company.Name,
                Description = "C Firması Teklif Tutarı",
                PlateNumber = customer.PlateNumber,
                Price = 300 + rndPrice
            };
            return offer;
        }
    }
}
