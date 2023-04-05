namespace NewsWise.Models
{
    public class Claimant
    {
        public int ClaimantId { get; set; }
        public string ClaimantName { get; set; }
        public virtual ICollection<Claim> Claims { get;}
    }
}