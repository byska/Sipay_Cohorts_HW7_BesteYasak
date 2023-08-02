using Microsoft.EntityFrameworkCore;
using Sipay_Cohorts_HW7.Entities.DbSets;

namespace Sipay_Cohorts_HW7.DataAccess.Context
{
    public class BookStoreDbContext :DbContext,IBookStoreDbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options):base(options)
        {
            
        }
        public DbSet<Book>Books { get; set; }
        public DbSet<Genre>Genres { get; set; }
        public DbSet<Author>Authors { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
