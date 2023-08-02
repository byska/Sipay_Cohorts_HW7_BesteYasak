using FluentAssertions;
using Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Commands;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands;
using Sipay_Cohorts_HW7.Api.Applications.GenreOperations.Commands;
using Sipay_Cohorts_HW7.DataAccess.Context;
using Sipay_Cohorts_HW7.UnitTests.Application.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sipay_Cohorts_HW7.UnitTests.Application.GenreOperations.Commands.DeleteGenreCommands
{
    public class DeleteGenreCommandTests: IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;
        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }
        [Fact]
        public void WhenTheDeleteGenreIsNotFoundWithTheGivenId_InvalidOperationException_ShouldBeReturn()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_dbContext);
            var genre = _dbContext.Genres.OrderByDescending(x => x.Id).FirstOrDefault();
            command.Id = genre.Id + 1;

            FluentActions.Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>()
               .And.Message.Should().Be("Kitap türü bulunamadı");
        }
        [Fact]
        public void WhenFoundTheDeleteGenreWithTheGivenId_Book_ShouldBeDeleted()
        {

            DeleteGenreCommand command = new DeleteGenreCommand(_dbContext);
            var genre = _dbContext.Genres.OrderBy(x => x.Id).FirstOrDefault();
            command.Id = genre.Id;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var deletedGenre = _dbContext.Genres.Find(genre.Id);
            deletedGenre.Should().BeNull();
        }
    }
}
