using FluentAssertions;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands;
using Sipay_Cohorts_HW7.Api.Applications.GenreOperations.Commands;
using Sipay_Cohorts_HW7.Api.Validator.Book;
using Sipay_Cohorts_HW7.Api.Validator.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohorts_HW7.UnitTests.Application.GenreOperations.Commands.CreateGenreCommands
{
    public class CreateGenreCommandValidatorTest
    {
        [Theory]
        [InlineData("a")]
        [InlineData("")]
        [InlineData(" ")]
        public void WhenInvalidInputsAreGivenGenre_Validator_ShouldBeReturnErrors(string name)
        {
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel()
            {
               Name=name
            };

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGivenGenre_Validator_ShouldNotBeReturnError()
        {
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel()
            {
                Name= "Attempt"
            };

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);

        }
    }
}
