using AutoMapper;
using FluentAssertions;
using Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Queries;
using Sipay_Cohorts_HW7.Api.Applications.GenreOperations.Queries;
using Sipay_Cohorts_HW7.DataAccess.Context;
using Sipay_Cohorts_HW7.UnitTests.Application.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohorts_HW7.UnitTests.Application.GenreOperations.Query.GetGenreDetailQueries
{
    public class GetGenreDetailQueriesTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGenreDetailQueriesTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenTheGenreIsNotFoundWithTheGivenId_InvalidOperationException_ShouldBeReturn()
        {
            GetGenreDetailsQuery query = new GetGenreDetailsQuery(_dbContext, _mapper);
            var genre = _dbContext.Genres.OrderByDescending(x => x.Id).FirstOrDefault();
            query.Id = genre.Id + 1;

            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Kitap Türü Bulunamadı.");
        }
        [Fact]
        public void WhenFoundTheGenreWithTheGivenId_Author_ShouldBeGet()
        {
            GetGenreDetailsQuery query = new GetGenreDetailsQuery(_dbContext, _mapper);
            var genre = _dbContext.Genres.OrderBy(x => x.Id).FirstOrDefault();
            query.Id = genre.Id;

            var getGenre = FluentActions.Invoking(() => query.Handle()).Invoke();

            getGenre.Should().NotBeNull();
            getGenre.Name = genre.Name;
            getGenre.Id = genre.Id;
        }
    }
}
