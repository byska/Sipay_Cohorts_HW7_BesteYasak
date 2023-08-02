using AutoMapper;
using Sipay_Cohorts_HW7.DataAccess.Context;

namespace Sipay_Cohorts_HW7.Api.Applications.GenreOperations.Queries
{
    public class GetGenreQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GenreViewModel> Handle()
        {
            var genres=_context.Genres.Where(x=>x.IsActive==true).OrderBy(x=>x.Id);
            List<GenreViewModel> returnObj =_mapper.Map<List<GenreViewModel>>(genres);
            return returnObj;
        }
       
    }
    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
