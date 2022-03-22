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
                        CoverPictureURL = "https://cdn.pixabay.com/photo/2019/10/13/20/07/house-4547140_960_720.jpg",
                        Description = "En lägenhet",
                        Price = 10000000,
                        NumberOfRooms = 5,
                        LivingArea = 180,
                        ConstructionYear = DateTime.Parse("1997-5-5"),
                        ShowDate = DateTime.Parse("2022-5-5"),
                        RealEstateType = RealEstateTypes.Lägenhet

                    },

                    new RealEstate
                    {
                        Address = "Gatan 5",
                        CoverPictureURL = "https://cdn.pixabay.com/photo/2016/08/26/15/06/home-1622401_960_720.jpg",
                        Description = "Ett hus",
                        Price = 7000000,
                        NumberOfRooms = 4,
                        LivingArea = 110,
                        ConstructionYear = DateTime.Parse("1999-5-5"),
                        ShowDate = DateTime.Parse("2020-5-5"),
                        RealEstateType = RealEstateTypes.Hus
                    },

                    new RealEstate
                    {

                        Address = "Mossvägen 5",
                        CoverPictureURL = "https://cdn.pixabay.com/photo/2019/01/13/11/49/iceland-3930162_960_720.jpg",
                        Description = "Ett hus",
                        Price = 7870000,
                        NumberOfRooms = 7,
                        LivingArea = 220,
                        ConstructionYear = DateTime.Parse("1999-5-5"),
                        ShowDate = DateTime.Parse("2020-5-5"),
                        RealEstateType = RealEstateTypes.Hus

                    },

                    new RealEstate
                    {
                        Address = "Blåbärsvägen 5",
                        CoverPictureURL = "https://cdn.pixabay.com/photo/2017/07/07/13/55/giethoorn-2481483_960_720.jpg",
                        Description = "Ett hus",
                        Price = 11000000,
                        NumberOfRooms = 6,
                        LivingArea = 160,
                        ConstructionYear = DateTime.Parse("1999-5-5"),
                        ShowDate = DateTime.Parse("2022-04-12"),
                        RealEstateType = RealEstateTypes.Hus

                    },

                    new RealEstate
                    {
                        Address = "Bondegatan 5",
                        CoverPictureURL = "https://cdn.pixabay.com/photo/2017/03/19/01/43/living-room-2155376_960_720.jpg",
                        Description = "En lägenhet på Söder",
                        Price = 3800000,
                        NumberOfRooms = 1,
                        LivingArea = 34,
                        ConstructionYear = DateTime.Parse("1980-5-5"),
                        ShowDate = DateTime.Parse("2022-04-20"),
                        RealEstateType = RealEstateTypes.Lägenhet

                    }
                );

                context.SaveChanges();
            }
        }
    }
}