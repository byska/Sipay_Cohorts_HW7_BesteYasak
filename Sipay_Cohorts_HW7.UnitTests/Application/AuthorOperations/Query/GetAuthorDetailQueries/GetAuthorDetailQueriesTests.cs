using AutoMapper;
using FluentAssertions;
using Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Queries;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Queries;
using Sipay_Cohorts_HW7.DataAccess.Context;
using Sipay_Cohorts_HW7.UnitTests.Application.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohorts_HW7.UnitTests.Application.AuthorOperations.Query.GetAuthorDetailQueries
{
    public class GetAuthorDetailQueriesTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorDetailQueriesTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenTheAuthorIsNotFoundWithTheGivenId_InvalidOperationException_ShouldBeReturn()
        {
            GetByIdAuthorQuery query = new GetByIdAuthorQuery(_dbContext, _mapper);
            var author = _dbContext.Authors.OrderByDescending(x => x.Id).FirstOrDefault();
            query.Id = author.Id + 1;

            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("İlgili id ile bir yazar bulunamadı.");

        }
        [Fact]
        public void WhenFoundTheAuthorWithTheGivenId_Author_ShouldBeGet()
        {
            GetByIdAuthorQuery query = new GetByIdAuthorQuery(_dbContext, _mapper);
            var author = _dbContext.Authors.OrderBy(x => x.Id).FirstOrDefault();
            query.Id = author.Id;

           var getAuthor= FluentActions.Invoking(() => query.Handle()).Invoke();

            getAuthor.Should().NotBeNull();
            getAuthor.Name=author.Name;
            getAuthor.LastName=author.LastName;
            getAuthor.BirthDate=author.BirthDate;
        }
    }
}
