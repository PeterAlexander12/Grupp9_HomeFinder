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
                        Address = "Storgatan 6",
                        Pictures = "https://cdn.pixabay.com/photo/2019/10/13/20/07/house-4547140_960_720.jpg",
                        Description = "An apartment",
                        FormOfLease = "Bostadsrätt på engelska",
                        Price = 6000,
                        NumberOfRooms = 7,
                        LivingArea = 200,
                        ConstructionYear = DateTime.Parse("1999-5-5"),
                        ShowDate = DateTime.Parse("2020-5-5")
                    },

                    new RealEstate
                    {
                        Address = "Gatan 5",
                        Pictures = "https://cdn.pixabay.com/photo/2017/03/30/04/14/house-2187170_960_720.jpg",
                        Description = "A house",
                        FormOfLease = "Bostadsrätt på engelska",
                        Price = 7000,
                        NumberOfRooms = 7,
                        LivingArea = 200,
                        ConstructionYear = DateTime.Parse("1999-5-5"),
                        ShowDate = DateTime.Parse("2020-5-5")
                    },

                    new RealEstate
                    {

                        Address = "Mossvägen 5",
                        Pictures = "https://cdn.pixabay.com/photo/2019/01/13/11/49/iceland-3930162_960_720.jpg",
                        Description = "A house",
                        FormOfLease = "Bostadsrätt på engelska",
                        Price = 7870,
                        NumberOfRooms = 7,
                        LivingArea = 200,
                        ConstructionYear = DateTime.Parse("1999-5-5"),
                        ShowDate = DateTime.Parse("2020-5-5")
                    },

                    new RealEstate
                    {
                        Address = "Blåbärsvägen 5",
                        Pictures = "https://cdn.pixabay.com/photo/2017/07/07/13/55/giethoorn-2481483_960_720.jpg",
                        Description = "A house",
                        FormOfLease = "Bostadsrätt på engelska",
                        Price = 7000,
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