using Microsoft.EntityFrameworkCore;

namespace NewsWise.Models
{
    public class NewswiseDbContext : DbContext
    {
        public NewswiseDbContext(DbContextOptions<NewswiseDbContext> options) : base(options) { }

        public DbSet<Claimant> Claimants { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<ReviewPublisher> ReviewPublisher { get; set; }
        public DbSet<ClaimReview> Review { get; set; }

    }
}