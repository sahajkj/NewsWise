using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWise.Models
{
    public class Claim
    {
        public int claim_id { get; set; }
        public string text { get; set; }
        public int claimant_id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime claim_date { get; set; }
        public virtual List<Claim_Review> reviews { get; set; }
        public virtual Claimant Claimant { get; set; }
    }
}
