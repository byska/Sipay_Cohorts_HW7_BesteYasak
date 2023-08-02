using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sipay_Cohorts_HW7.DataAccess.Context;
using Sipay_Cohorts_HW7.Entities.DbSets;

namespace Sipay_Cohorts_HW7.DataAccess.Seed
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Authors.AddRange(new Author()
                {
                    Name="John",
                    LastName="Doe",
                    BirthDate=new DateTime(1998,02,16)
                    
                },
                new Author()
                {
                    Name = "Jeyn",
                    LastName = "Doe",
                    BirthDate = new DateTime(2007, 01, 24)
                },
                new Author()
                {
                    Name = "Tom",
                    LastName = "Doe",
                    BirthDate = new DateTime(1972, 08, 02)
                });
                context.Genres.AddRange(new Genre()
                {
                    Name = "Personal Growth"
                },
                new Genre()
                {
                    Name = "Science Fiction"
                },
                new Genre()
                {
                    Name = "Romance"
                });
                context.Books.AddRange(new Book()
                {
                    Id = 1,
                    Title = "Lean Startup",
                    GenreId = 1,
                    PageCount = 250,
                    PublishDate = new DateTime(2001, 10, 12),
                    AuthorId=1

                },
                new Book
                {
                    Id = 2,
                    Title = "Herland",
                    GenreId = 1,
                    PageCount = 250,
                    PublishDate = new DateTime(2011, 05, 12),
                    AuthorId=2

                },
                 new Book
                 {
                     Id = 3,
                     Title = "Dune",
                     GenreId = 2,
                     PageCount = 540,
                     PublishDate = new DateTime(2001, 12, 12),
                     AuthorId=2
                 }
                );
                context.SaveChanges();
            }
        }
    }
}
