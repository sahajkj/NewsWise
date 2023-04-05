using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace NewsWise.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string Text { get; set; }
        public int ClaimantId { get; set; }
        [AllowNull]
        public DateTime? ClaimDate { get; set; }
        public virtual ICollection<ClaimReview> Claim_Reviews { get; set; }
    }
}
