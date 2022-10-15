using Microsoft.EntityFrameworkCore;
using Quiz.Application.Interfaces;
using Quiz.Domain;
using Quiz.Persistence.EntityTypeConfiguration;

namespace Quiz.Persistence
{
    public class QuizDbContext : DbContext, IQuizDbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options)
            : base(options) { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new QuestionConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
