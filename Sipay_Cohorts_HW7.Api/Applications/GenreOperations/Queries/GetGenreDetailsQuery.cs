using AutoMapper;
using Sipay_Cohorts_HW7.DataAccess.Context;

namespace Sipay_Cohorts_HW7.Api.Applications.GenreOperations.Queries
{
    public class GetGenreDetailsQuery
    {
        public int Id { get; set; }

        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreDetailsQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GenresViewModel Handle()
        {
            var genres = _context.Genres.SingleOrDefault(x => x.IsActive == true && x.Id==Id);
            if(genres == null)
            {
                throw new InvalidOperationException("Kitap Türü Bulunamadı.");
            }
            GenresViewModel returnObj = _mapper.Map<GenresViewModel>(genres);
            return returnObj;
        }
       
    }
    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
