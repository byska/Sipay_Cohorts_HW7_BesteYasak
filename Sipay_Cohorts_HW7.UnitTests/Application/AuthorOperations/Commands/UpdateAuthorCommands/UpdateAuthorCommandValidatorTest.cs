using FluentAssertions;
using Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Commands;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands;
using Sipay_Cohorts_HW7.Api.Validator.Author;
using Sipay_Cohorts_HW7.Api.Validator.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohorts_HW7.UnitTests.Application.AuthorOperations.Commands.UpdateAuthorCommands
{
    public class UpdateAuthorCommandValidatorTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenUpdateAuthorIdValueIsLessThanAndEqualZero_Validator_ShouldBeReturnErrors(int id)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.Id = id;
            command.Model = new UpdateAuthorViewModel()
            {
                Name = "Mark",
                LastName = "Doe",
                BirthDate = DateTime.Now.AddYears(-2)
            };
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData("aa","aaa")]
        [InlineData("aaa","aa")]
        [InlineData("aaa","")]
        [InlineData("","aaa")]
        [InlineData("aaaaa","aa")]
        public void WhenInvalidInputsAreGivenUpdateAuthor_Validator_ShouldBeReturnErrors(string name, string lastname)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.Model = new UpdateAuthorViewModel
            {
                Name = name,
                LastName = lastname,
                BirthDate = DateTime.Now.AddYears(-1)
            };
            command.Id = 1;

            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGivenUpdateAuthor_Validator_ShouldBeReturnError()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.Model = new UpdateAuthorViewModel
            {
                Name = "Jack",
                LastName = "Doe",
                BirthDate = DateTime.Now.Date
            };
            command.Id = 1;
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("Jack", " ")]
        [InlineData(" ", "Yasak")]
        [InlineData("Jack", "Yasak")]
        public void WhenValidInputsAreGivenUpdateAuthor_Validator_ShouldNotBeReturnError(string name, string lastname)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.Model = new UpdateAuthorViewModel
            {
                Name = name,
                LastName = lastname,
                BirthDate = DateTime.Now.Date.AddYears(-2)
            };
            command.Id = 1;
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
