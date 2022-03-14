using HomeFinder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace HomeFinder.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HomeFinderContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HomeFinderContext>>()))
            {
                if (context.RealEstate.Any())
                {
                    return;
                }

                context.RealEstate.AddRange(
                    new RealEstate
                    {
                        Address = "Vägen 5",
                        Pictures = "https://cdn.pixabay.com/photo/2019/10/13/20/07/house-4547140_960_720.jpg",
                        Description = "A house",
                        FormOfLease = "Bostadsrätt på engelska",
                        Price = 1000M,
                        NumberOfRooms = 7,
                        LivingArea = 200,
                        ConstructionYear = DateTime.Parse("1999-5-5"),
                        ShowDate = DateTime.Parse("2020-5-5")
                    },

                    new RealEstate
                    {
                        Address = "Vägen 5",
                        Pictures = "https://cdn.pixabay.com/photo/2019/10/13/20/07/house-4547140_960_720.jpg",
                        Description = "A house",
                        FormOfLease = "Bostadsrätt på engelska",
                        Price = 1000M,
                        NumberOfRooms = 7,
                        LivingArea = 200,
                        ConstructionYear = DateTime.Parse("1999-5-5"),
                        ShowDate = DateTime.Parse("2020-5-5")
                    },

                    new RealEstate
                    {
                        Address = "Vägen 5",
                        Pictures = "https://cdn.pixabay.com/photo/2019/10/13/20/07/house-4547140_960_720.jpg",
                        Description = "A house",
                        FormOfLease = "Bostadsrätt på engelska",
                        Price = 1000M,
                        NumberOfRooms = 7,
                        LivingArea = 200,
                        ConstructionYear = DateTime.Parse("1999-5-5"),
                        ShowDate = DateTime.Parse("2020-5-5")
                    }
                );

                context.SaveChanges();
            }
        }
    }
}