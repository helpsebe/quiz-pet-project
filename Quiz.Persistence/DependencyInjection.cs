﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<QuizDbContext>(options =>
            {
                options.UseSqlServer(connectionString, m =>
                m.MigrationsAssembly("BookStore.Persistence"));
            });
            services.AddScoped<IQuizDbContext>(provider =>
                provider.GetService<QuizDbContext>());

            return services;
        }
    }
}