using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceOffer.Model.Models
{
    public interface IdentityPKEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }
    }
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
