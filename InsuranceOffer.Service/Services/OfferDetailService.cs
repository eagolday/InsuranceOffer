using InsuranceOffer.Data.Infrastructure;
using InsuranceOffer.Data.Repositories;
using InsuranceOffer.Model.Models;
using InsuranceOffer.Service.Models.Response;
using InsuranceOffer.Service.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.Service.Services
{
    public interface IOfferDetailService
    {

        void CreateOfferDetail(OfferDetail offerDetail);

        //tc ile geçmiş sorgulama.
        List<OfferDetail> GetCustomerOfferDetails(string uniqueIdentifierNumber);

        //burada servise istek atılacak
        List<OfferDetail> GetAllCompanyOfferDetails(Customer customer);
        //void SaveCustomer();
    }

    public class OfferDetailService : IOfferDetailService
    {
        private readonly IOfferDetailRepository _offerDetailRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyService _companyService;
        private readonly IApiService _apiService;
        private readonly ICustomerService _customerService;

        public OfferDetailService(IOfferDetailRepository offerDetailRepository, ICustomerService customerService,
            ICompanyService companyService, IApiService apiService, IUnitOfWork unitOfWork)
        {
            _companyService = companyService;
            _apiService = apiService;
            _customerService = customerService;
            _offerDetailRepository = offerDetailRepository;
            _unitOfWork = unitOfWork;
        }


        public List<OfferDetail> GetAllCompanyOfferDetails(Customer customer)
        {
            // var _customer = _customerService.CreateCustomer(customer);
            CustomerModel requestModel = new CustomerModel
            {
                PlateNumber = customer.PlateNumber,
                SerialCode = customer.SerialCode,
                SerialNumber = customer.SerialNumber,
                UniqueIdentifierNumber = customer.UniqueIdentifierNumber
            };

            List<OfferDetail> offerDetails = new List<OfferDetail>();
            var companies = _companyService.GetCompanies();
          
            foreach (var item in companies)
            {

                string url = item.ServiceUrl;
                var postResult = _apiService.PostMethod<OfferModel>(requestModel,  url);

                if (postResult != null && postResult.CompanyId > 0)
                {
                    var responseDetail = new OfferDetail
                    {
                        CompanyId = postResult.CompanyId,
                        CustomerId = customer.Id,
                        Price = postResult.Price,
                        Description = postResult.Description,
                    };


                    responseDetail.Customer = customer;
                    responseDetail.Company = _companyService.GetCompany(postResult.CompanyId);
                    _offerDetailRepository.Add(responseDetail);
                    _unitOfWork.Commit();

                    offerDetails.Add(responseDetail);
                }
            }


            return offerDetails;
        }

        public List<OfferDetail> GetCustomerOfferDetails(string uniqueIdentifierNumber)
        {
            var allHistory = _offerDetailRepository
                .GetMany(x =>  x.IsDeleted == false && x.Customer.UniqueIdentifierNumber == uniqueIdentifierNumber).ToList();
            return allHistory;
        }

        public void CreateOfferDetail(OfferDetail offerDetail)
        {
            _offerDetailRepository.Add(offerDetail);
            SaveCustomer();
        }
        public void SaveCustomer()
        {
            _unitOfWork.Commit();
        }
    }
}
