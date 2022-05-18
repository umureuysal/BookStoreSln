using Microsoft.EntityFrameworkCore;

namespace WebApi.Context
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider ServiceProvider)
        {
            using (var context = new ApplicationDbContext(ServiceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                new Book
                {
                    //Id = 1,
                    Title = "Lean Startup",
                    GenreId = 1,
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 05, 13)
                },
                new Book
                {
                    //Id = 2,
                    Title = "Herland",
                    GenreId = 2,
                    PageCount = 250,
                    PublishDate = new DateTime(2010, 05, 22)
                },
                new Book
                {
                    //Id = 3,
                    Title = "Doom",
                    GenreId = 2,
                    PageCount = 540,
                    PublishDate = new DateTime(2003, 12, 23)
                }
                );
                context.SaveChanges();
            };


        }
    }
}

