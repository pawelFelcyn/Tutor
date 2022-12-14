using Tutor.Server.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Tutor.Server.Infrastructure;
using Tutor.Server.Application;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
       .AddDbContext<TutorDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TutorDbConnection")))
       .AddInfrastructure()
       .AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
