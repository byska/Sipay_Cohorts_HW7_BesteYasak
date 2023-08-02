using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Commands;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands;
using Sipay_Cohorts_HW7.DataAccess.Context;
using Sipay_Cohorts_HW7.Entities.DbSets;
using Sipay_Cohorts_HW7.UnitTests.Application.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohorts_HW7.UnitTests.Application.AuthorOperations.Commands.DeleteAuthorCommands
{
    public class DeleteAuthorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;
        public DeleteAuthorCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }
        [Fact]
        public void WhenTheDeleteAuthorIsNotFoundWithTheGivenId_InvalidOperationException_ShouldBeReturn()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_dbContext);
            var author = _dbContext.Authors.OrderByDescending(x => x.Id).FirstOrDefault();
            command.Id = author.Id + 1;

            FluentActions.Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>()
               .And.Message.Should().Be("Verilen id ile bir yazar bulunmamaktadır.");
        }
        [Fact]
        public void WhenThereIsBookRegisteredToTheAuthor_InvalidOperationException_ShouldBeReturn()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_dbContext);
            command.Id = 2;

            FluentActions.Invoking(() => command.Handle())
              .Should().Throw<InvalidOperationException>()
              .And.Message.Should().Be("Yazarı silebilmek için önce yazarın kitaplarını silmelisiniz.");
        }
        [Fact]
        public void WhenFoundTheDeleteAuthorWithTheGivenIdAndHasNotBook_Author_ShouldBeDeleted()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_dbContext);
            var author = _dbContext.Authors.OrderBy(x => x.Id).FirstOrDefault();
            var books = _dbContext.Books.Where(x => x.AuthorId == author.Id).ToList();
            if(books.Count() > 0)
            {
                foreach (var book in books)
                {
                    _dbContext.Books.Remove(book);

                }
                _dbContext.SaveChanges();
            }
           
            command.Id = author.Id;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var deletedAuthor = _dbContext.Authors.Find(author.Id);
            deletedAuthor.Should().BeNull();
        }
    }
}
