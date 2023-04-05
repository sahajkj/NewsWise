namespace NewsWise.Models
{
    public class ReviewPublisher
    {
        public int ReviewPublisherId { get; set; }
        public string Publisher { get; set; }
        public string Site { get; set; }
        public virtual ICollection<ClaimReview> ClaimReviews { get; set; }
    }
}
