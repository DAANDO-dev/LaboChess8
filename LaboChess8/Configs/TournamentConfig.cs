using LaboChess8.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaboChess8.Configs
{
    public class TournamentConfig : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.MinPlayers).IsRequired();
            builder.Property(t => t.MaxPlayers).IsRequired();
            builder.Property(t => t.Status).HasDefaultValue("In progress");
            builder.Property(t => t.CurrentRound).HasDefaultValue(0);
            builder.Property(t => t.WomenOnly).HasDefaultValue(false);
            builder.Property(t => t.RegistrationDeadLine).HasDefaultValue(DateTime.Now.AddDays(7));
            builder.Property(t => t.CreationDate).HasDefaultValue(DateTime.Now);
            builder.Property(t => t.Update).HasDefaultValue(DateTime.Now);
        }

        
    }
}
