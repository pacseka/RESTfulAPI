using RESTfulAPI.Infrastructure;
using RESTfulAPI.Infrastructure.Models;
using System;


namespace RESTfulAPI.Services
{
    public class DataSeeder
    {
        public static void SeedData(SwordContext context)
        {
            context.BlackSimths.AddRange(new BlackSmith
            {
                Description = "Középföldei kovácsmester",
                Id = Guid.Parse("f27aaaa2-0cdd-4fb6-a2fc-a942289705f2"),
                Name = "Telchar",
                Race = "törpe",
                Guild = "Nogrod"
            },
            new BlackSmith
            {
                Description = "Skót kovácsmester",
                Id = Guid.Parse("5ef095fd-101d-4a45-9542-1a6b8e5ee609"),
                Name = "Sean Wallace",
                Race = "ember",
                Guild = "Felföldi Kardkészítők",
                BirthDate = new DateTime(1412, 2, 27)
            },
            new BlackSmith
            {
                Description = "Mágikus kovács",
                Id = Guid.Parse("1485107e-8ac8-4c8b-8e7b-82d57874f1a5"),
                Name = "Merlin",
                Race = "fey"
            });

            context.Swords.AddRange(new Sword
            {
                BlackSmithId = Guid.Parse("f27aaaa2-0cdd-4fb6-a2fc-a942289705f2"),
                Name = "Narsil",
                Description = "A Kettétört Kard. Elendil, Izildur majd Aragorn kardja.",
                LengthCm = 100,
                WeightKg = 1,
                Status = DTO.Status.ReadyToKill,
                Type = "Hosszúkard",
                Id = Guid.Parse("89347c0a-d9fa-4e23-ad84-311948581cbb")
            },
            new Sword
            {
                BlackSmithId = Guid.Parse("5ef095fd-101d-4a45-9542-1a6b8e5ee609"),
                Name = "MacLeod kardja",
                Description = "MacLeod családi kardja",
                LengthCm = 110,
                WeightKg = 2.2m,
                Type = "Claymore",
                Id = Guid.Parse("4663fd75-3571-4ee8-83ec-82c04f6e9b51")
            },
            new Sword
            {
                BlackSmithId = Guid.Parse("5ef095fd-101d-4a45-9542-1a6b8e5ee609"),
                Name = "Kurgan kardja",
                Description = "Kurgan családi kardja",
                LengthCm = 126,
                WeightKg = 2.8m,
                Type = "Claymore",
                Id = Guid.Parse("940c3e22-53c7-4f21-9246-abda489448fb")
            },
            new Sword
            {
                Name = "Excalibur",
                Description = "Ha jó ember húzgálja, akkor kijön és király lesz.",
                LengthCm = 90,
                WeightKg = 1,
                Type = "Hosszúkard",
                Id = Guid.Parse("43aa15b6-04d0-4140-ab32-0da06ad32dc7")
            });



            context.SaveChanges();
        }
    }
}
