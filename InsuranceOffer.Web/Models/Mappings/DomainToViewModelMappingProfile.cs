using AutoMapper;
using InsuranceOffer.Model.Models;
using InsuranceOffer.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceOffer.Web.Models.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
     //       Mapper.CreateMap<GoodEntity, GoodDTO>()
     //.ForMember(dto => dto.providers, opt => opt.MapFrom(x => x.GoodsAndProviders.Select(y => y.Providers).ToList()));

  //          Mapper.CreateMap<GoodEntity, GoodDTO>()
  //.ForMember(dto => dto.providers, opt => opt.MapFrom(x => x.GoodsAndProviders));

            Mapper.CreateMap<Customer, CustomerViewModel>()
                .ForMember(vm=>vm.OfferDetailModels,e=>e.MapFrom(x=>x.OfferDetails));
 
            Mapper.CreateMap<Company, CompanyViewModel>()
                .ForMember(vm => vm.OfferDetailModels, e => e.MapFrom(x => x.OfferDetails)); 
           
            Mapper.CreateMap<OfferDetail, OfferDetailViewModel>()
                .ForMember(vm=>vm.CompanyModel,e=>e.MapFrom(x=>x.Company))
                .ForMember(vm => vm.CustomerModel, e => e.MapFrom(x => x.Customer));


           
        }
    }
}