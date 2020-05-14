using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace InsuranceOffer.Model.Models
{

    public class Customer: BaseEntitiy, ISoftDelete
    {
        public Customer()
        {
            CreateDate = DateTime.Now;
            IsDeleted = false;
            this.OfferDetails = new HashSet<OfferDetail>();
        }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }

        public string UniqueIdentifierNumber { get; set; }
        public string PlateNumber { get; set; }
        public string SerialNumber { get; set; }
        public string SerialCode { get; set; }

        public virtual ICollection<OfferDetail> OfferDetails { get; set; }
    }
}
