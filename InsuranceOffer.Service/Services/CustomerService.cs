using InsuranceOffer.Data.Infrastructure;
using InsuranceOffer.Data.Repositories;
using InsuranceOffer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.Service.Services
{
    public interface ICustomerService
    {
        Customer CreateCustomer(Customer customer);
        Customer GetCustomer(string uniqueIdentifierNumber, string plateNumber);

        //void SaveCustomer();
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public Customer CreateCustomer(Customer customer)
        {
            var isExist = _customerRepository.Get(x =>  x.IsDeleted == false &&
              x.UniqueIdentifierNumber == customer.UniqueIdentifierNumber && x.PlateNumber == customer.PlateNumber);

            if (isExist != null)
                return isExist;
            else
            {
                _customerRepository.Add(customer);
                SaveCustomer();

                return _customerRepository.Get(x => x.IsDeleted == false &&
              x.UniqueIdentifierNumber == customer.UniqueIdentifierNumber && x.PlateNumber == customer.PlateNumber);

            }
        }

        public Customer GetCustomer(string uniqueIdentifierNumber, string plateNumber)
        {
            return _customerRepository.Get(x => x.IsDeleted == false && x.UniqueIdentifierNumber == uniqueIdentifierNumber && x.PlateNumber == plateNumber);
        }

        public void SaveCustomer()
        {
            _unitOfWork.Commit();
        }
    }
}
