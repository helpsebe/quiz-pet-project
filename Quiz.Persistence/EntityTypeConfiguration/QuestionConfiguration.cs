using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Domain;

namespace Quiz.Persistence.EntityTypeConfiguration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(qstn=>qstn.Id);
            builder.Property(qstn => qstn.Title).HasMaxLength(40).IsRequired();
            builder.Property(qstn => qstn.Option1).HasMaxLength(60);
            builder.Property(qstn => qstn.Option2).HasMaxLength(60);
            builder.Property(qstn => qstn.Option3).HasMaxLength(60);
            builder.Property(qstn => qstn.Option4).HasMaxLength(60);
            builder.Property(qstn => qstn.Answer).IsRequired();
        }
    }
}
