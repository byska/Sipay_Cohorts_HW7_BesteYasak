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

namespace Sipay_Cohorts_HW7.UnitTests.Application.AuthorOperations.Commands.DeleteAuthorCommands
{
    public class DeleteAuthorCommandValidatorTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenDeleteAuthorIdValueIsLessThanAndEqualZero_Validator_ShouldBeReturnErrors(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            command.Id = id;

            DeleteAuthorValidation validator = new DeleteAuthorValidation();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDeleteAuthorIdValueIsMoreThanZero_Validator_ShouldNotBeReturnError()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            command.Id = 1;

            DeleteAuthorValidation validator = new DeleteAuthorValidation();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);

        }
    }
}
