using Tutor.Server.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Tutor.Server.Infrastructure;
using Tutor.Server.Application;
using Tutor.Shared.Validators;
using FluentValidation.AspNetCore;
using NLog.Web;
using Tutor.Server.API.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.UseNLog();
builder.Services
       .AddDbContext<TutorDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TutorDbConnection")))
       .AddInfrastructure()
       .AddApplication()
       .AddValidators()
       .AddFluentValidationAutoValidation()
       .AddScoped<ErrorHandlingMiddleware>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
