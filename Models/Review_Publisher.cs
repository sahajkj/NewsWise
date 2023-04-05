namespace NewsWise.Models
{
    public class Review_Publisher
    {
        public int publisher_id { get; set; }
        public string publisher { get; set; }
        public string site { get; set; }
        public virtual List<Claim_Review> reviews { get; set; }
    }
}
