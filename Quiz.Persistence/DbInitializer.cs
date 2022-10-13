using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(QuizDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
