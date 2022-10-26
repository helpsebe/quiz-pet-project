using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Application.Common.Behaviors;
using System.Reflection;

namespace Quiz.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
           this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
