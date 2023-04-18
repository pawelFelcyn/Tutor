using Tutor.Server.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Tutor.Server.Infrastructure;
using Tutor.Server.Application;
using Tutor.Shared.Validators;
using FluentValidation.AspNetCore;
using NLog.Web;
using Tutor.Server.API.Middleware;
using Tutor.Server.Application.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tutor.Server.API;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.UseNLog();

var authenticationSettings = new AuthenticationSettings();
builder.Configuration.GetSection("AuthenticationSettings").Bind(authenticationSettings);
builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddAuthentication("Bearer")
       .AddJwtBearer(cfg =>
       {
           cfg.RequireHttpsMetadata = false;
           cfg.SaveToken = true;
           cfg.TokenValidationParameters = new()
           {
               ValidIssuer = authenticationSettings.JwtIssuer,
               ValidAudience = authenticationSettings.JwtIssuer,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
           };
       });

builder.Services
       .AddDbContext<TutorDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TutorDbConnection")))
       .AddInfrastructure()
       .AddApplication()
       .AddValidators()
       .AddFluentValidationAutoValidation()
       .AddScoped<ErrorHandlingMiddleware>()
       .AddHttpContextAccessor()
       .AddScoped<DataSeeder>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("allowAll", policy =>
    {
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

var dataSeeder = app.Services.CreateScope().ServiceProvider.GetService<DataSeeder>();
await dataSeeder.SeedData();

app.Run();

public partial class Program { }
