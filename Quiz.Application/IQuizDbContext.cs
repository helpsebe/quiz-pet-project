using Microsoft.EntityFrameworkCore;
using Quiz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application
{
    public interface IQuizDbContext
    {
        DbSet<Question> Questions { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
