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
    public interface ICompanyService
    {
        IEnumerable<Company> GetCompanies();
        Company GetCompany(int id);
        Company GetCompanyByname(string name);
        void CreateCompany(Company company);
        //void SaveCompany();
    }
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateCompany(Company company)
        {
            _companyRepository.Add(company);
            SaveCompany();
        }

        public IEnumerable<Company> GetCompanies()
        {
            var companies = _companyRepository.GetMany(x => x.IsDeleted==false);
            return companies;
        }

        public Company GetCompany(int id)
        {
           var company= _companyRepository.GetById(id);
            return company;
        }

        public Company GetCompanyByname(string name)
        {
            var company = _companyRepository.GetCompanyByName(name);
            return company;
        }

        public void SaveCompany()
        {
            _unitOfWork.Commit();
        }
    }
}
