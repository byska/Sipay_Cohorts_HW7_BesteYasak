using AutoMapper;
using Sipay_Cohorts_HW7.DataAccess.Context;

namespace Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Queries
{
    public class GetAuthorQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<AuthorViewModel> Handle()
        {
            var author = _dbContext.Authors.OrderBy(x=>x.Name);
            List<AuthorViewModel> viewModel= _mapper.Map<List<AuthorViewModel>>(author);    
            return viewModel;
        }
    }
    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
