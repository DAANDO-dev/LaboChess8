using LaboChess8.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaboChess8.Configs
{
    public class MemberConfig : IEntityTypeConfiguration<Member>

    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(m => m.Username).IsRequired();
            builder.Property(m => m.Email).IsRequired();
            builder.Property(m => m.BirthDate).IsRequired();
            builder.Property(m => m.Password).IsRequired();


        }

        
        
    }
}
