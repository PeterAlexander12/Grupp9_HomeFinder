using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeFinder.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.Extensions.Hosting;

namespace HomeFinder.Data
{
    public class HomeFinderContext : IdentityDbContext<ApplicationUser>
    {
        public HomeFinderContext (DbContextOptions<HomeFinderContext> options)
            : base(options)
        {
        }

        public DbSet<RealEstate> RealEstate { get; set; }

        public DbSet<RegistrationOfInterest> RegistrationOfInterest { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<RegistrationOfInterest>()
        //        .HasOne(i => i.RealEstate)
        //        .WithMany(r => r.RegistrationsOfInterest)
        //        .HasForeignKey(i => i.Id)
        //        .HasPrincipalKey(r => r.Id);
        //    base.OnModelCreating(modelBuilder);

        //}

    }
}
