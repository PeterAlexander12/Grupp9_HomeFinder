using System;
using System.Linq;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RealEstateContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RealEstateContext>>()))
            {
                if (context.RealEstates.Any())
                {
                    return;
                }


                context.RealEstates.AddRange(
                     new RealEstate
                     {
                         Address = "Madenvägen 8",
                         City = "Lerum",
                         CoverPictureURL = "https://images.unsplash.com/photo-1586982599726-11708daaceca?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1742&q=80",
                         Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae.",
                         Price = 8500000,
                         NumberOfRooms = 6,
                         LivingArea = 180,
                         LotArea = 2304,
                         ConstructionYear = DateTime.Parse("1999-8-1"),
                         ShowDate = DateTime.Parse("2022-5-5"),
                         RealEstateType = RealEstateTypes.Hus,
                         FormOfLease = FormOfLease.Äganderätt,
                     },
                    new RealEstate
                    {
                        Address = "Eslöv 288",
                        City = "Eslöv",
                        CoverPictureURL = "https://images.unsplash.com/photo-1431287991645-d6583750a66c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1746&q=80",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Price = 7150000,
                        NumberOfRooms = 5,
                        LivingArea = 224,
                        SubsidiaryArea = 60,
                        LotArea = 40000,
                        ConstructionYear = DateTime.Parse("1997-5-5"),
                        ShowDate = DateTime.Parse("2022-5-20"),
                        RealEstateType = RealEstateTypes.Gård,
                        FormOfLease = FormOfLease.Äganderätt
                    },
                    new RealEstate
                    {

                        Address = "Drosbacken 501",
                        City = "Älvdalen",
                        CoverPictureURL = "https://images.unsplash.com/photo-1449158743715-0a90ebb6d2d8?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Price = 1395000,
                        NumberOfRooms = 3,
                        LivingArea = 54,
                        SubsidiaryArea = 12,
                        LotArea = 780,
                        ConstructionYear = DateTime.Parse("2000-1-1"),
                        ShowDate = DateTime.Parse("2022-5-12"),
                        RealEstateType = RealEstateTypes.Hus,
                        FormOfLease = FormOfLease.Äganderätt
                    },
                    new RealEstate
                    {
                        Address = "Gatan 5",
                        City = "Onsala",
                        CoverPictureURL = "https://images.unsplash.com/photo-1600585152220-90363fe7e115?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                        Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. ",
                        Price = 5950000,
                        NumberOfRooms = 4,
                        LivingArea = 180,
                        LotArea = 850,
                        ConstructionYear = DateTime.Parse("2002-5-5"),
                        ShowDate = DateTime.Parse("2022-5-15"),
                        RealEstateType = RealEstateTypes.Hus,
                        FormOfLease = FormOfLease.Äganderätt
                    },
                    new RealEstate
                    {
                        Address = "Mossvägen 5",
                        City = "Kristianstad",
                        CoverPictureURL = "https://images.unsplash.com/photo-1599427303058-f04cbcf4756f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1742&q=80",
                        Description = "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor sit amet consectetur adipisci[ng] velit, sed quia non numquam [do] eius modi tempora inci[di]dunt, ut labore et dolore magnam aliquam quaerat voluptatem.",
                        Price = 6870000,
                        NumberOfRooms = 4,
                        LivingArea = 120,
                        SubsidiaryArea = 40,
                        LotArea = 1518,
                        ConstructionYear = DateTime.Parse("1999-5-5"),
                        ShowDate = DateTime.Parse("2022-4-28"),
                        RealEstateType = RealEstateTypes.Hus,
                        FormOfLease = FormOfLease.Äganderätt
                    },
                    new RealEstate
                    {
                        Address = "Blåbärsvägen 5",
                        City = "Lidingö",
                        CoverPictureURL = "https://images.unsplash.com/photo-1583608205776-bfd35f0d9f83?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80",
                        Description = "At vero eos et accusamus et iusto odio dignissimos ducimus, qui blanditiis praesentium voluptatum deleniti atque corrupti, quos dolores et quas molestias excepturi sint, obcaecati cupiditate non provident, similique sunt in culpa, qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio, cumque nihil impedit, quo minus id, quod maxime placeat, facere possimus, omnis voluptas assumenda est, omnis dolor repellendus.",
                        Price = 12900000,
                        NumberOfRooms = 6,
                        LivingArea = 205,
                        SubsidiaryArea = 20,
                        LotArea = 880,
                        ConstructionYear = DateTime.Parse("1999-5-5"),
                        ShowDate = DateTime.Parse("2022-05-12"),
                        RealEstateType = RealEstateTypes.Hus,
                        FormOfLease = FormOfLease.Äganderätt
                    },

                    new RealEstate
                    {
                        Address = "Bondegatan 5",
                        City = "Stockholm",
                        CoverPictureURL = "https://images.unsplash.com/photo-1502672260266-1c1ef2d93688?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1380&q=80",
                        Description = "Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet, ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.",
                        Price = 3895000,
                        NumberOfRooms = 1,
                        LivingArea = 34,
                        ConstructionYear = DateTime.Parse("1980-5-5"),
                        ShowDate = DateTime.Parse("2022-04-29"),
                        RealEstateType = RealEstateTypes.Lägenhet,
                        FormOfLease = FormOfLease.Bostadsrätt,

                    },

                     new RealEstate
                     {
                         Address = "Storgatan 6",
                         City = "Stockholm",
                         CoverPictureURL = "https://images.unsplash.com/photo-1584475242790-6838d981ebdb?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                         Description = "Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor sit amet consectetur adipisci[ng] velit, sed quia non numquam [do] eius modi tempora inci[di]dunt, ut labore et dolore magnam aliquam quaerat voluptatem.",
                         Price = 10995000,
                         NumberOfRooms = 5,
                         LivingArea = 102,
                         SubsidiaryArea = 14,
                         ConstructionYear = DateTime.Parse("1997-5-5"),
                         ShowDate = DateTime.Parse("2022-5-5"),
                         RealEstateType = RealEstateTypes.Lägenhet,
                         FormOfLease = FormOfLease.Bostadsrätt,
                     },

                     new RealEstate
                     {
                         Address = "Bäckhult 10",
                         City = "Älmhult",
                         CoverPictureURL = "https://images.unsplash.com/photo-1634744533210-b717cf95597e?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80",
                         Description = "Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet, ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.",
                         Price = 2850000,
                         NumberOfRooms = 7,
                         LivingArea = 215,
                         SubsidiaryArea = 35,
                         LotArea = 13000,
                         ConstructionYear = DateTime.Parse("1920-5-5"),
                         ShowDate = DateTime.Parse("2022-5-20"),
                         RealEstateType = RealEstateTypes.Gård,
                         FormOfLease = FormOfLease.Äganderätt,
                     },

                     new RealEstate
                     {
                         Address = "Klumgatan 6",
                         City = "Piteå",
                         CoverPictureURL = "https://images.unsplash.com/photo-1493809842364-78817add7ffb?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80",
                         Description = "Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor sit amet consectetur adipisci[ng] velit, sed quia non numquam [do] eius modi tempora inci[di]dunt, ut labore et dolore magnam aliquam quaerat voluptatem.",
                         Price = 825000,
                         NumberOfRooms = 2,
                         LivingArea = 48,
                         ConstructionYear = DateTime.Parse("2000-5-5"),
                         ShowDate = DateTime.Parse("2022-5-26"),
                         RealEstateType = RealEstateTypes.Lägenhet,
                         FormOfLease = FormOfLease.Bostadsrätt,
                     });

                context.SaveChanges();


                context.RealEstateImages.AddRange(
                new RealEstateImage
                {
                    ImageURL = "aab53b6b-89de-4bbc-b75c-2187d5af13fb-naomi-hebert-MP0bgaS_d1c-unsplash.jpg	",
                    RealEstate = context.RealEstates.First(r => r.Id == 1)
                },
                new RealEstateImage
                {
                    ImageURL = "c02b6e84-d9f4-4bb6-89ad-96a7cc9323c9-collov-home-design-RE_j7uRsS6E-unsplash.jpg",
                    RealEstate = context.RealEstates.First(r => r.Id == 1)
                },
                new RealEstateImage
                {
                    ImageURL = "024a5215-cba3-4576-a462-e54f315276c9-sidekix-media-8qNuR1lIv_k-unsplash.jpg",
                    RealEstate = context.RealEstates.First(r => r.Id == 1)
                },
                new RealEstateImage
                {
                    ImageURL = "0c4ae4a4-c5a3-487b-8cdb-ab9f94a42f50-spacejoy-uGWNcejbf2E-unsplash.jpg",
                    RealEstate = context.RealEstates.First(r => r.Id == 1)
                },
               new RealEstateImage
               {
                   ImageURL = "094da773-f815-4544-9fac-bf2c5a48be32-home-gf9c73ff85_1920.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 2)
               },
               new RealEstateImage
               {
                   ImageURL = "01827524-dd88-4021-99d1-21675b6add55-garlic-g2ea7d368c_1920.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 2)
               },
               new RealEstateImage
               {
                   ImageURL = "74b6dc31-06be-4089-92cc-e4adcf7a8aa2-francesca-tosolini-tDVvS8eOMig-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 2)
               },
               new RealEstateImage
               {
                   ImageURL = "2edd8c28-e604-4237-a9d9-7148766c6133-sidekix-media-ghhDWuGK9QY-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 2)
               },
               new RealEstateImage
               {
                   ImageURL = "c201f80b-f2c5-428e-b7e3-ec7e53cb3a4e-pete-willis-Y1P7S9QvbgQ-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 2)
               },
               new RealEstateImage
               {
                   ImageURL = "5714c2e7-78e0-4f40-b25a-4dc4bda3165f-hans-isaacson-bQTVoJHrkO0-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 3)
               },

               new RealEstateImage
               {
                   ImageURL = "847473d9-f308-4cd3-afd6-3bb3e02c30be-hans-isaacson-uX8wVtW5PQo-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 3)
               },
               new RealEstateImage
               {
                   ImageURL = "c9993b8a-e73f-4f7a-a9ad-d04d44a16f0b-andrew-spencer-B2RKwf2IaJU-unsplash.jpg	",
                   RealEstate = context.RealEstates.First(r => r.Id == 3)
               },
               new RealEstateImage
               {
                   ImageURL = "25631f78-5ab5-4184-baaa-1c7efd0a9ac5-justin-kauffman-fpoHihXiMhg-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 3)
               },
               new RealEstateImage
               {
                   ImageURL = "42459092-394b-4455-9ca2-4a756c911d61-r-architecture-T6d96Qrb5MY-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 4)
               },
               new RealEstateImage
               {
                   ImageURL = "c9102701-aa05-40d6-8246-4fde26400fb5-r-architecture-CCjAPxoQWgQ-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 4)
               },
               new RealEstateImage
               {
                   ImageURL = "876677f0-e8a8-4df2-aad9-b545108a0cb1-sidekix-media-g51F6-WYzyU-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 4)
               },
               new RealEstateImage
               {
                   ImageURL = "4173f903-2cd0-4252-a006-e196b6655f13-zac-gudakov-5QLCohwVndQ-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 4)
               },
               new RealEstateImage
               {
                   ImageURL = "76bcac9b-0e00-4eeb-89d8-9a13b8f94caa-sidekix-media-wRzBarqn3hs-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 5)
               },
               new RealEstateImage
               {
                   ImageURL = "f21d0cfc-ae1e-46ad-bef2-b777922a9a98-collov-home-design-kSoe7EoxHIE-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 5)
               },
               new RealEstateImage
               {
                   ImageURL = "4a9251f3-6813-4559-b371-f8fd3061e4c1-bedroom-g97decb858_1920.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 5)
               },
               new RealEstateImage
               {
                   ImageURL = "24cfb979-4d3f-4d5e-8f24-ce801e0c6f62-birgit-loit-yaAh6fIp9NE-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 5)
               },
                new RealEstateImage
                {
                    ImageURL = "2533fbb1-9d6e-4d14-a3fc-6a30be02116d-roam-in-color-z3QZ6gjGRt4-unsplash.jpg",
                    RealEstate = context.RealEstates.First(r => r.Id == 6)
                },
               new RealEstateImage
               {
                   ImageURL = "13eb1df8-3280-41d1-8e6b-b1927c64e76d-roam-in-color-zzMb7jacyBc-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 6)
               },
               new RealEstateImage
               {
                   ImageURL = "4e9fcddf-60ca-4a46-95e6-56bff7c51b50-roam-in-color-AwOG1tC5buE-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 6)
               },
               new RealEstateImage
               {
                   ImageURL = "2a80da14-e1f0-43bf-aeb4-fb50910622c9-spacejoy-808a4AWu8jE-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 6)
               },
               new RealEstateImage
               {
                   ImageURL = "654875d5-30a4-4026-8d76-e7e1e0a3eb3f-spacejoy-9M66C_w_ToM-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 6)
               },
               new RealEstateImage
               {
                   ImageURL = "9fbb73c6-6f74-4297-a75d-d87b9cbf10e9-francesca-tosolini-XcVm8mn7NUM-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 6)
               },
               new RealEstateImage
               {
                   ImageURL = "06e63983-5aa1-4c0d-906f-71058b9b882c-artur-aleksanian-6-nCXHU1hKk-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 7)
               },
               new RealEstateImage
               {
                   ImageURL = "03c0a916-13c7-4045-92ac-e589383c60be-bathroom-g2e61f801e_1920.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 7)
               }, new RealEstateImage
               {
                   ImageURL = "8e083045-bdea-4615-a7c0-90cfad12d02e-croissant--BiyRLfotEQ-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 8)
               }, new RealEstateImage
               {
                   ImageURL = "2e3123c0-5c39-49bd-9f1d-d6905951fb1d-arpa-sarian-OkvGjvyGNFc-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 8)
               }, new RealEstateImage
               {
                   ImageURL = "a9e28988-c91e-4f48-96a6-60abce513bbf-robby-mccullough-ZWGexQLecAI-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 8)
               }, new RealEstateImage
               {
                   ImageURL = "9395479e-7117-4615-9332-d791bb4cbfb3-gritt-zheng-LDETWUdEiHU-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 9)
               }, new RealEstateImage
               {
                   ImageURL = "a4d06a8a-0e9a-4452-98ac-78798519c371-nolan-issac-K5sjajgbTFw-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 9)
               }, new RealEstateImage
               {
                   ImageURL = "33d8147c-b1e1-4d25-a644-31730ed27411-peter-herrmann-6p-OzDhqeyI-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 9)
               }, new RealEstateImage
               {
                   ImageURL = "e341a83a-a937-4249-ad8a-43ebecc2af38-brett-jordan-DsCsI1RNRTk-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 9)
               }, new RealEstateImage
               {
                   ImageURL = "dc074508-494d-4d5b-a291-75e4e169bb63-christopher-jolly-GqbU78bdJFM-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 10)
               }, new RealEstateImage
               {
                   ImageURL = "4b0ab36d-dd45-4e23-9cf2-1a315cd42569-rune-enstad-UXFJ-6Zj27M-unsplash.jpg",
                   RealEstate = context.RealEstates.First(r => r.Id == 10)
               }
               );

                context.Roles.AddRange(
                    new Microsoft.AspNetCore.Identity.IdentityRole
                    {
                        Id= "2cc2174b-3b0e-446d-86cs-421n56gd8172",
                        Name = "realtor"
                    },
                    new Microsoft.AspNetCore.Identity.IdentityRole
                    {
                        Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                        Name = "admin"
                    }
                    );

                context.Users.AddRange(
                    new ApplicationUser
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                        Email = "admin@homefinder.se",
                        GivenName = "John",
                        SurName = "Doe",
                        UserName = "admin@homefinder.se",
                        PhoneNumber = "0701234567",
                        PasswordHash = "Admin1234!"
                    }
                    );

                context.UserRoles.AddRange(
                    new Microsoft.AspNetCore.Identity.IdentityUserRole<string>
                    {
                        RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}