using Microsoft.EntityFrameworkCore;
using Shelter2.Data;

namespace Shelter2.Models
{
    public class SeedDate
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Shelter2Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Shelter2Context>>()))
            {
                // Look for any movies.
                if (context.Pets.Any())
                {
                    return;   // DB has been seeded
                }
                context.Pets.AddRange(
                    new Pets
                    {
                        Name = "Клепочка",
                        Date = DateTime.Parse("14/08/2024"),
                        TypeOfInspection  = "Осмотр хвостика",
                        Age = 8,
                        Price = 3.200M
                    },
                    new Pets
                    {
                        Name = "Ариша",
                        Date = DateTime.Parse("01/06/2023"),
                        TypeOfInspection  = "Лечение вкусняшками",
                        Age = 10,
                        Price = 8.99M
                    },
                    new Pets
                    {
                        Name = "Иша",
                        Date = DateTime.Parse("31/12/2024"),
                        TypeOfInspection  = "Раскрас шерстки",
                        Age = 1,
                        Price = 9.99M
                    },
                    new Pets
                    {
                        Name = "Луша",
                        Date = DateTime.Parse("2/5/2025"),
                        TypeOfInspection  = "Нахождение дома",
                        Age = 3,
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
}
}
