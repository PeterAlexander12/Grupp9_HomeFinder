using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace HomeFinder.Data
{
    public class RealEstateContext : IdentityDbContext
    {
        public RealEstateContext (DbContextOptions<RealEstateContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Favourite>().HasKey(f => new {f.UserId, f.RealEstateId});
        }

        public DbSet<RealEstate> RealEstate { get; set; }

        public DbSet<RegistrationOfInterest> RegistrationOfInterest { get; set; }

        public DbSet<RealEstateImage> RealEstateImages { get; set; }

        public DbSet<Favourite> Favourites { get; set; }

    }
}
