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
                        Date = DateTime.Parse("14.08.2024"),
                        TypeOfInspection  = "Осмотр хвостика",
                        Price = 3.200M
                    },
                    new Pets
                    {
                        Name = "Ghostbusters ",
                        Date = DateTime.Parse("1984-3-13"),
                        TypeOfInspection  = "Comedy",
                        Price = 8.99M
                    },
                    new Pets
                    {
                        Name = "Ghostbusters 2",
                        Date = DateTime.Parse("1986-2-23"),
                        TypeOfInspection  = "Comedy",
                        Price = 9.99M
                    },
                    new Pets
                    {
                        Name = "Rio Bravo",
                        Date = DateTime.Parse("1959-4-15"),
                        TypeOfInspection  = "Western",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
}
}
