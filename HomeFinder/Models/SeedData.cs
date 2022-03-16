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
                        Description = "An appartment",
                        FormOfLease = "Bostadsrätt på engelska",
<<<<<<< HEAD
                        Price = 6500000M,
=======
                        Price = 7000000,
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
                        Price = 7000000,
>>>>>>> b1ce262c168580b947cc65dd8a322588cb7aae3d
                        NumberOfRooms = 7,
                        LivingArea = 200,
                        ConstructionYear = DateTime.Parse("1999-5-5"),
                        ShowDate = DateTime.Parse("2020-5-5")
                    },

                    new RealEstate
                    {
<<<<<<< HEAD
                        Address = "Mossvägen 25",
                        Pictures = "https://cdn.pixabay.com/photo/2019/10/13/20/07/house-4547140_960_720.jpg",
                        Description = "A house",
                        FormOfLease = "Bostadsrätt på engelska",
                        Price = 2300000M,
=======
                        Address = "Vägen 5",
                        Pictures = "https://cdn.pixabay.com/photo/2019/01/13/11/49/iceland-3930162_960_720.jpg",
                        Description = "A house",
                        FormOfLease = "Bostadsrätt på engelska",
                        Price = 7000000,
>>>>>>> b1ce262c168580b947cc65dd8a322588cb7aae3d
                        NumberOfRooms = 7,
                        LivingArea = 200,
                        ConstructionYear = DateTime.Parse("1999-5-5"),
                        ShowDate = DateTime.Parse("2020-5-5")
                    },

                    new RealEstate
                    {
<<<<<<< HEAD
                        Address = "Blåbärsvägen 4",
                        Pictures = "https://cdn.pixabay.com/photo/2019/10/13/20/07/house-4547140_960_720.jpg",
                        Description = "A house",
                        FormOfLease = "Bostadsrätt på engelska",
                        Price = 8000000M,
=======
                        Address = "Vägen 5",
                        Pictures = "https://cdn.pixabay.com/photo/2017/07/07/13/55/giethoorn-2481483_960_720.jpg",
                        Description = "A house",
                        FormOfLease = "Bostadsrätt på engelska",
                        Price = 7000000,
>>>>>>> b1ce262c168580b947cc65dd8a322588cb7aae3d
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