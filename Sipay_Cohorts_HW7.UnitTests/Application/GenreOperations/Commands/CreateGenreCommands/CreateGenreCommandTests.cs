using AutoMapper;
using FluentAssertions;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands;
using Sipay_Cohorts_HW7.Api.Applications.GenreOperations.Commands;
using Sipay_Cohorts_HW7.DataAccess.Context;
using Sipay_Cohorts_HW7.Entities.DbSets;
using Sipay_Cohorts_HW7.UnitTests.Application.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohorts_HW7.UnitTests.Application.GenreOperations.Commands.CreateGenreCommands
{
    public class CreateGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;

        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }
        [Fact]
        public void WhenAlreadyExistGenreTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrrange
            var genre = new Genre() { Name="Advanture" };
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(_dbContext);
            command.Model = new CreateGenreModel() { Name = genre.Name };

            //act && assert(çalıştırma ve doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü zaten mevcut");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
        {
            //arrange
            CreateGenreCommand command = new CreateGenreCommand(_dbContext);
            var createGenre = new CreateGenreModel() { Name="Roman"};
            command.Model = createGenre;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == createGenre.Name);
            genre.Should().NotBeNull();
        }
    }
}
