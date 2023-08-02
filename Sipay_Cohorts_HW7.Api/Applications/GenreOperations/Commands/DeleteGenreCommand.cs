using Sipay_Cohorts_HW7.DataAccess.Context;

namespace Sipay_Cohorts_HW7.Api.Applications.GenreOperations.Commands
{
    public class DeleteGenreCommand
    {
        public int Id { get; set; }

        private readonly IBookStoreDbContext _dbContext;

        public DeleteGenreCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var genre=_dbContext.Genres.SingleOrDefault(x=>x.Id==Id);
            if(genre == null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı");
            }
            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }
    }

}
