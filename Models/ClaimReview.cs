using System.Diagnostics.CodeAnalysis;

namespace NewsWise.Models
{
    public class ClaimReview
    {
        public int ClaimReviewId { get; set; }
        [AllowNull]
        public string? Title { get; set; }
        public string Url { get; set; }
        [AllowNull]
        public DateTime? ReviewDate { get; set; }
        public string TextualRating { get; set; }
        public int ClaimId { get; set; }
        public int ReviewPublisherId { get; set; }
    }
}