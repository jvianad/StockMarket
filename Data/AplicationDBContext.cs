using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockMarket.Models;
using System.Data;

namespace StockMarket.Data
{
    public class AplicationDBContext: IdentityDbContext<AppUser>
    {
        public AplicationDBContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id="Admin",
                    Name="Admin",
                    NormalizedName="ADMIN"
                },
                new IdentityRole
                {
                    Id="User",
                    Name="User",
                    NormalizedName="USER"
                },
                
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

        }
        

    }
}
