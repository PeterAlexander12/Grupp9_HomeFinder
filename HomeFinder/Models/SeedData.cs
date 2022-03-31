using HomeFinder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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

                        Address = "Eslöv 288",
                        CoverPictureURL = "https://images.unsplash.com/photo-1431287991645-d6583750a66c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1173&q=80",
                        Description = "En gård. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Price = 8500000,
                        NumberOfRooms = 5,
                        LivingArea = 220,
                        ConstructionYear = DateTime.Parse("1997-5-5"),
                        ShowDate = DateTime.Parse("2022-5-5"),
                        RealEstateType = RealEstateTypes.Gård

                    },

                    new RealEstate
                    {
                        Address = "Gatan 5",
                        CoverPictureURL = "https://cdn.pixabay.com/photo/2016/08/26/15/06/home-1622401_960_720.jpg",
                        Description = "Ett hus. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. ",
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

                    },
                     new RealEstate
                     {
                         Address = "Storgatan 6",
                         CoverPictureURL = "https://images.unsplash.com/photo-1584475242790-6838d981ebdb?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                         Description = "En lägenhet",
                         Price = 10000000,
                         NumberOfRooms = 5,
                         LivingArea = 180,
                         ConstructionYear = DateTime.Parse("1997-5-5"),
                         ShowDate = DateTime.Parse("2022-5-5"),
                         RealEstateType = RealEstateTypes.Lägenhet

                     }
                ) ;

                context.SaveChanges();
            }
        }
    }
}