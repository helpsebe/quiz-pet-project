using Quiz.Application;
using Quiz.Application.Common.Mappings;
using Quiz.Application.Interfaces;
using Quiz.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IQuizDbContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetRequiredService<QuizDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception)
    {
    }
}

app.UseRouting();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();