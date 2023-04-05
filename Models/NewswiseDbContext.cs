using Microsoft.EntityFrameworkCore;

namespace NewsWise.Models
{
    public class NewswiseDbContext : DbContext
    {
        public NewswiseDbContext(DbContextOptions<NewswiseDbContext> options) : base(options) { }

        public DbSet<Claimant>
    }
}
