using Microsoft.EntityFrameworkCore;

namespace CQRS_PatternImplement.Models
{
    public class FootballDbContext :DbContext
    {
        public FootballDbContext(DbContextOptions<FootballDbContext> options):base(options)
        {
            
        }

        public DbSet<Player> Players { get; set; }  
    }
}
