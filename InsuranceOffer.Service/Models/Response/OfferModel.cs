using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.Service.Models.Response
{
   public class OfferModel
    {
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }

        public string PlateNumber { get; set; }
    }
}
