using AutoMapper;
using FluentAssertions;
using Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Commands;
using Sipay_Cohorts_HW7.DataAccess.Context;
using Sipay_Cohorts_HW7.UnitTests.Application.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohorts_HW7.UnitTests.Application.AuthorOperations.Commands.UpdateAuthorCommands
{
    public class UpdateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;

        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }
        [Fact]
        public void WhenTheUpdateAuthorIsNotFoundWithTheGivenId_InvalidOperationException_ShouldBeReturn()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_dbContext);
            var author=_dbContext.Authors.OrderByDescending(author => author.Id).FirstOrDefault();
            UpdateAuthorViewModel model = new UpdateAuthorViewModel()
            {
                Name = "Jason",
                LastName = "Doe",
                BirthDate = DateTime.Now.AddYears(-2)
            };
            command.Id = author.Id + 1;
            command.Model=model;

            FluentActions.Invoking(() => command.Handle())
              .Should().Throw<InvalidOperationException>()
              .And.Message.Should().Be("İlgili yazar bulunamadı.");

        }
        [Fact]
        public void WhenAlreadyExistAuthorIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            UpdateAuthorCommand command = new UpdateAuthorCommand(_dbContext);
            var author = _dbContext.Authors.OrderBy(author => author.Id).FirstOrDefault();
            command.Id = author.Id;
            command.Model =new UpdateAuthorViewModel() { Name=author.Name, LastName=author.LastName,BirthDate=author.BirthDate};

            FluentActions.Invoking(() => command.Handle())
              .Should().Throw<InvalidOperationException>()
              .And.Message.Should().Be("Aynı isimli yazar zaten mevcut");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeUpdated()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_dbContext);
            var author = _dbContext.Authors.OrderBy(author => author.Id).FirstOrDefault();
            command.Id = author.Id;
            UpdateAuthorViewModel model = new UpdateAuthorViewModel() { Name = "Charlie", LastName = "Doe", BirthDate = new DateTime(2009,05,29) };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var updatedAuthor=_dbContext.Authors.SingleOrDefault(x=>x.Id == author.Id);
            updatedAuthor.Should().NotBeNull();
            updatedAuthor.Name.Should().Be(model.Name);
            updatedAuthor.LastName.Should().Be(model.LastName);
            updatedAuthor.BirthDate.Should().Be(model.BirthDate);
        }
    }
}
