using AutoMapper;
using InsuranceOffer.Model.Models;
using InsuranceOffer.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceOffer.Web.Models.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {

            Mapper.CreateMap<CustomerViewModel,Customer >()
               .ForMember(e => e.OfferDetails, vm => vm.MapFrom(x => x.OfferDetailModels));

            Mapper.CreateMap<CompanyViewModel,Company >()
                .ForMember(e => e.OfferDetails , vm => vm.MapFrom(x => x.OfferDetailModels));

            Mapper.CreateMap<OfferDetailViewModel,OfferDetail >()
                .ForMember(e => e.Company, vm => vm.MapFrom(x => x.CompanyModel))
                .ForMember(e => e.Customer, vm => vm.MapFrom(x => x.CustomerModel));
        }
    }
}