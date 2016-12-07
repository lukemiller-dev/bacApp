using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AlcoholApp.Models;

namespace AlcoholApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<Glass> Glasses { get; set; }
        public DbSet<Night> Nights { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Alcohol>().HasMany(g => g.Glasses).WithOne(a => a.Alcohol);
            builder.Entity<Night>().HasMany(g => g.Glasses).WithOne(n => n.Night);
            builder.Entity<ApplicationUser>().HasMany(n => n.Nights).WithOne(a => a.ApplicationUser);
            builder.Entity<Glass>().HasKey(g => new { g.NightId, g.AlcoholId });
            base.OnModelCreating(builder);
            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
