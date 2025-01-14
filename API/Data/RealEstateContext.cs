﻿using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
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

        public DbSet<RealEstate> RealEstates { get; set; }

        public DbSet<RegistrationOfInterest> RegistrationOfInterest { get; set; }

        public DbSet<RealEstateImage> RealEstateImages { get; set; }

        public DbSet<Favourite> Favourites { get; set; }

    }
}
