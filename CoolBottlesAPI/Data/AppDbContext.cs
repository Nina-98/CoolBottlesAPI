using CoolBottlesAPI.Models;
using CoolBottlesAPI.Models.DB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CoolBottlesAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Bottle> Bottles { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // always call this first when using Identity

            builder.Entity<Bottle>()
                .Property(b => b.Price)
                .HasPrecision(18, 3); // specify decimal precision/scale
        }
    }
}
