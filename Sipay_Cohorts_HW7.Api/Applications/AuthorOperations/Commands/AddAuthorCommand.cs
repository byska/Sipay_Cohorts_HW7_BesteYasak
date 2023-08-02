using AutoMapper;
using Sipay_Cohorts_HW7.DataAccess.Context;
using Sipay_Cohorts_HW7.Entities.DbSets;

namespace Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Commands
{
    public class AddAuthorCommand
    {
        public AddAuthorViewModel Model { get; set; }

        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public AddAuthorCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.Where(x => x.Name == Model.Name && x.LastName == Model.LastName).FirstOrDefault();
            if (author is not null)
            {
                throw new InvalidOperationException("Girilen yazarın kaydı vardır.");
            }

            Author CreateAuthor =_mapper.Map<Author>(Model);
            _dbContext.Authors.Add(CreateAuthor);
            _dbContext.SaveChanges();
        }
    }
    public class AddAuthorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
