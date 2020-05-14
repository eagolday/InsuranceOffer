using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.Service.Models.Request
{
    public class CustomerModel
    {
        public string UniqueIdentifierNumber { get; set; }
        public string PlateNumber { get; set; }
        public string SerialNumber { get; set; }
        public string SerialCode { get; set; }
    }
}
