using Microsoft.EntityFrameworkCore;
using Quiz.Application;
using Quiz.Domain;
using Quiz.Persistence.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Persistence
{
    public class QuizDbContext:DbContext, IQuizDbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext>options)
            :base(options) { }

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
