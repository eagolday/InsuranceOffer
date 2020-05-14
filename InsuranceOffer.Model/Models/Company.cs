using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace InsuranceOffer.Model.Models
{
    public class Company : BaseEntitiy, ISoftDelete
    {
        public Company()
        {
            CreateDate = DateTime.Now;
            IsDeleted = false;
            this.OfferDetails = new HashSet<OfferDetail>();
        }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string Name { get; set; }
        public string Logo { get; set; }
        public string ServiceUrl { get; set; }


        public virtual ICollection<OfferDetail> OfferDetails { get; set; }

    }

}
