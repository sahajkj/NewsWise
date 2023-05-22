using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace NewsWise.Models
{
    public class ClaimReview
    {
        public int ClaimReviewId { get; set; }
        [AllowNull]
        [MaxLength(256)]
        public string? Title { get; set; }
        public string Url { get; set; }
        [AllowNull]
        public DateTime? ReviewDate { get; set; }
        [MaxLength(1500)]
        public string TextualRating { get; set; }
        public int ClaimId { get; set; }
        public int ReviewPublisherId { get; set; }
    }
}