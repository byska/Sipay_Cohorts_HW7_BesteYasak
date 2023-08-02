using Sipay_Cohorts_HW7.DataAccess.Context;

namespace Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands
{
    public class DeleteBookCommand
    {
        public int Id { get; set; }

        private readonly IBookStoreDbContext _dbContext;
        public DeleteBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.Find(Id);
            if (book is null)
            {
                throw new InvalidOperationException("Verilen id'de bir kitap yoktur.");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

    }
}
