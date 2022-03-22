using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeFinder.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HomeFinder.Data
{
    public class HomeFinderContext : IdentityDbContext
    {
        public HomeFinderContext (DbContextOptions<HomeFinderContext> options)
            : base(options)
        {
        }

        public DbSet<RealEstate> RealEstate { get; set; }

        public DbSet<RegistrationOfInterest> RegistrationOfInterest { get; set; }

        public DbSet<RealEstateImage> RealEstateImages { get; set; }

    }
}
