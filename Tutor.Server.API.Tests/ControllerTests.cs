﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tutor.Server.Domain.Entities;
using Tutor.Server.Infrastructure.Database;

namespace Tutor.Server.API.Tests;

public class ControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
	protected readonly WebApplicationFactory<Program> _factory;

	public ControllerTests(WebApplicationFactory<Program> factory)
	{
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var dbContextService = services.FirstOrDefault(s => s.ServiceType == typeof(TutorDbContext));
                services.Remove(dbContextService!);
                var optionsBuilder = new DbContextOptionsBuilder();
                optionsBuilder.UseInMemoryDatabase("TutorDb");
                var context = new TutorDbContext(optionsBuilder.Options);
                services.AddSingleton(context);
            });
        });
    }

    protected User SeedUser(string role = "User")
    {
        var scope = _factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<TutorDbContext>();
        var hasher = scope.ServiceProvider.GetService<IPasswordHasher<User>>();
        var user = new User
        {
            FirstName = "Test",
            LastName = "Test",
            Role = role,
            Email = "email",
        };
        user.PasswordHash = hasher!.HashPassword(user, "password");
        dbContext!.Users.Add(user);
        dbContext.SaveChanges();
        return user;
    }
}