using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using InsuranceOffer.Data;
using InsuranceOffer.Model.Models;
using InsuranceOffer.Service.Services;
using InsuranceOffer.Web.Models.ViewModels;

namespace InsuranceOffer.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;

        }

        public ActionResult Index()
        {
            var companies = _companyService.GetCompanies().ToList();
            var companyViewModels = Mapper.Map<List<Company>, List<CompanyViewModel>>(companies);

            return View(companyViewModels);
        }       
    }
}
