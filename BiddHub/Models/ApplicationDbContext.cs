using BiddHub.Models.Authentication.Register;
using BiddHub.Models.Listings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BiddHub.Models
{
    //The DbContext is responsible for interacting with the database. Use Entity Framework Core for database interactions.
    public class ApplicationDbContext : IdentityDbContext<RegisterUser,IdentityRole<Guid>,Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Private method that adds few roles
        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "Bidder", ConcurrencyStamp = "2", NormalizedName = "Bidder" },
                new IdentityRole() { Name = "Auctioneer", ConcurrencyStamp = "3", NormalizedName = "Auctioneer" }

                );
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Photos> ProductImages { get; set; }
        public DbSet<Documents> ProductDocuments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }


    }
    

}
