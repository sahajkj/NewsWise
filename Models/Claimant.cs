namespace NewsWise.Models
{
    public class Claimant
    {
        public int claimant_id { get; set; }
        public string claimant { get; set; }
        public virtual List<Claim> claims { get; set;}
    }
}