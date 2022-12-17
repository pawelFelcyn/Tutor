using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Server.Domain.Entities;

namespace Tutor.Server.Infrastructure.Database;

public class TutorDbContext : DbContext
{
    public TutorDbContext(DbContextOptions options)
        :base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Advertisement> Advertisements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(e =>
        {
            e.Property(u => u.FirstName)
             .IsRequired()
             .HasMaxLength(50);
            e.Property(u => u.LastName)
             .IsRequired()
             .HasMaxLength(50);
            e.Property(u => u.Role)
             .IsRequired();
            e.Property(u => u.Email)
             .IsRequired();
            e.Property(u => u.PasswordHash)
             .IsRequired();
        });

        modelBuilder.Entity<Advertisement>(e =>
        {
            e.Property(a => a.Title)
             .IsRequired()
             .HasMaxLength(100);
            e.Property(a => a.Description)
             .HasMaxLength(1000);
            e.Property(a => a.PricePerHour)
             .HasPrecision(2);
        });
    }
}
