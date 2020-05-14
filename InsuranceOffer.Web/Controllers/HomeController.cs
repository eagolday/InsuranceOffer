using AutoMapper;
using InsuranceOffer.Model.Models;
using InsuranceOffer.Service.Services;
using InsuranceOffer.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InsuranceOffer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IOfferDetailService _offerDetailService;

        public HomeController(ICustomerService customerService, IOfferDetailService offerDetailService)
        {
            _offerDetailService = offerDetailService;
            _customerService = customerService;

        }

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult GetOffer()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetOffer(CustomerViewModel customerModel)
        {
            if (!ModelState.IsValid)
                return View(customerModel);

            var mapCustomer = Mapper.Map<CustomerViewModel, Customer>(customerModel);
            var customer = _customerService.CreateCustomer(mapCustomer);

            var offerDetails = _offerDetailService.GetAllCompanyOfferDetails(customer);
            if (!offerDetails.Any())
                return HttpNotFound();
            else
            {
                var offerDetailViewModels = Mapper.Map<List<OfferDetail>, List<OfferDetailViewModel>>(offerDetails);
                TempData["offerDetails"] = offerDetailViewModels;
                return RedirectToAction("OfferDetails");
            }
        }


        public ActionResult OfferHistory()
        {
            ViewBag.OfferHistory = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OfferHistory(UniqueViewModel uniqueViewModel)
        {
            if (!ModelState.IsValid)
                return View(uniqueViewModel);

            var offerDetails = _offerDetailService.GetCustomerOfferDetails(uniqueViewModel.UniqueIdentifierNumber);
            if (!offerDetails.Any())
            {
                ViewBag.OfferHistory = "Kaydınız bulunamadı. Teklif al adımından yeni talep oluşturabilirsiniz.";
                return View();
            }
            else
            {
                var offerDetailViewModels = Mapper.Map<List<OfferDetail>, List<OfferDetailViewModel>>(offerDetails);
                TempData["offerDetails"] = offerDetailViewModels;
                return RedirectToAction("OfferDetails");
            }
        }



        public ActionResult OfferDetails()
        {
            var offerDetails = TempData["offerDetails"] as List<OfferDetailViewModel>;
            if (offerDetails == null || offerDetails.Count == 0 || !offerDetails.Any())
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(offerDetails);
        }

        [HttpGet]
        public JsonResult CheckCustomer(string uniq, string plate)
        {
            if (string.IsNullOrEmpty(uniq)|| string.IsNullOrEmpty(plate)) 
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
       
            var customer = _customerService.GetCustomer(uniq, plate);
            if (customer == null)
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            return Json(new { success = true, sn = customer.SerialNumber, sc = customer.SerialCode }, JsonRequestBehavior.AllowGet);
        }
    }
}