using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Domain;

namespace Quiz.Persistence.EntityTypeConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id);
            //builder.Property(u => u.Role).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Score).HasDefaultValue(0);
        }
    }
}
