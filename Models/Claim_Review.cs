namespace NewsWise.Models
{
    public class Claim_Review
    {
        public string review_id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public DateTime review_date { get; set; }
        public string textual_rating { get; set; }
        public string claim_id { get; set; }
        public string publisher_id { get; set; }
        public virtual Claim claim { get; set; }
        public virtual Review_Publisher review_publisher { get; set; }
    }
}