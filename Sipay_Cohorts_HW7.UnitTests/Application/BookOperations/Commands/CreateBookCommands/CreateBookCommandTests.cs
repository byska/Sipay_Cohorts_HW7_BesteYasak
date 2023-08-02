using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands;
using Sipay_Cohorts_HW7.DataAccess.Context;
using Sipay_Cohorts_HW7.Entities.DbSets;
using Sipay_Cohorts_HW7.UnitTests.Application.TestSetup;

namespace Sipay_Cohorts_HW7.UnitTests.Application.BookOperations.Commands.CreateBookCommands
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrrange
            var book = new Book() { Title = "WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount = 100, PublishDate = new DateTime(1999, 02, 02), GenreId = 1, AuthorId = 2 };
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_dbContext, _mapper);
            command.Model = new CreateBookModel() { Title = book.Title };

            //act && assert(çalıştırma ve doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut.");


        }
        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(_dbContext, _mapper);
            var createBook = new CreateBookModel() { Title = "Hobbit", PageCount = 100, PublishDate = new DateTime(1999, 02, 02), GenreId = 1, AuthorId = 2 };
            command.Model = createBook;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == createBook.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(createBook.PageCount);
            book.PublishDate.Should().Be(createBook.PublishDate);
            book.GenreId.Should().Be(createBook.GenreId);
            book.AuthorId.Should().Be(createBook.AuthorId);
        }
    }
}
