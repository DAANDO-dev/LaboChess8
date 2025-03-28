using LaboChess8.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaboChess8
{
    public class LaboChessContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Member> Members { get; set; } = null!;
        public DbSet<Tournament> Tournaments { get; set; } = null!;
        public DbSet<Matchup> Matchups { get; set; } = null!;


    }
}
