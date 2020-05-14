using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceOffer.Web.Models.ViewModels
{
    public class UniqueViewModel
    {
        [DisplayName("Tc No"), Required(ErrorMessage = "Tc Zorunlu")]
        [MinLength(11, ErrorMessage = "Tc en az 11 karekter olmalıdır."), MaxLength(11, ErrorMessage = "Tc en fazla 11 karekter olmalıdır.")]
        public string UniqueIdentifierNumber { get; set; }
    }

    public class CustomerViewModel: UniqueViewModel
    {
      //  public int Id { get; set; }

        //[DisplayName("Tc No"), Required(ErrorMessage = "Tc Zorunlu")]
        //[MinLength(11, ErrorMessage = "Tc en az 11 karekter olmalıdır."), MaxLength(11, ErrorMessage = "Tc en fazla 11 karekter olmalıdır.")]
        //public string UniqueIdentifierNumber { get; set; }

        [DisplayName("Plaka"), Required(ErrorMessage = "Plaka Zorunlu")]
        public string PlateNumber { get; set; }

        [DisplayName("Seri No"), Required(ErrorMessage = "Seri No Zorunlu")]
        public string SerialNumber { get; set; }

        [DisplayName("Seri Kod"), Required(ErrorMessage = "Seri Kodu Zorunlu")]
        public string SerialCode { get; set; }

        public List<OfferDetailViewModel> OfferDetailModels { get; set; }
    }
}