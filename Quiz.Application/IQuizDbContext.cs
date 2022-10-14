using Microsoft.EntityFrameworkCore;
using Quiz.Domain;

namespace Quiz.Application
{
    public interface IQuizDbContext
    {
        DbSet<Question> Questions { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
