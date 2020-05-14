using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceOffer.Model.Models
{
    public class OfferDetail : BaseEntitiy, ISoftDelete
    {
        public OfferDetail()
        {
            CreateDate = DateTime.Now;
            IsDeleted = false;
        }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public DateTime CreateDate { get; set; }

        public int CompanyId { get; set; }
        public int CustomerId { get; set; }

        public string Description { get; set; }
        public decimal? Price { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
