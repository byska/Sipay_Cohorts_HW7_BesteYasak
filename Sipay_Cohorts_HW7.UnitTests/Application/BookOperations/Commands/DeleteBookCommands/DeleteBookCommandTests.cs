using FluentAssertions;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands;
using Sipay_Cohorts_HW7.DataAccess.Context;
using Sipay_Cohorts_HW7.Entities.DbSets;
using Sipay_Cohorts_HW7.UnitTests.Application.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohorts_HW7.UnitTests.Application.BookOperations.Commands.DeleteBookCommands
{
    public class DeleteBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;
        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }
        [Fact]
        public void WhenTheDeleteBookIsNotFoundWithTheGivenId_InvalidOperationException_ShouldBeReturn()
        {
            DeleteBookCommand command = new DeleteBookCommand(_dbContext);
            var book = _dbContext.Books.OrderByDescending(x=>x.Id).FirstOrDefault();
            command.Id=book.Id+1;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Verilen id'de bir kitap yoktur.");
        }
        [Fact]
        public void WhenFoundTheDeleteBookWithTheGivenId_Book_ShouldBeDeleted()
        {

            DeleteBookCommand command = new DeleteBookCommand(_dbContext);
            var book = _dbContext.Books.OrderBy(x => x.Id).FirstOrDefault();
            command.Id = book.Id;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var deletedBook = _dbContext.Books.Find(book.Id);
            deletedBook.Should().BeNull();
        }
    }
}
