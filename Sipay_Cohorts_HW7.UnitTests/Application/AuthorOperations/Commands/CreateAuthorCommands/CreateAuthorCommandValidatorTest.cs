using FluentAssertions;
using Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Commands;
using Sipay_Cohorts_HW7.Api.Validator.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sipay_Cohorts_HW7.UnitTests.Application.AuthorOperations.Commands.CreateAuthorCommands
{
    public class CreateAuthorCommandValidatorTest
    {
        [Theory]
        [InlineData("","")]
        [InlineData(" "," ")]
        [InlineData("aa","aaa")]
        [InlineData("aaa","aa")]
        [InlineData("aaaa","")]
        [InlineData("","aaaa")]
        public void WhenInvalidInputsAreGivenCreateAuthor_Validator_ShouldBeReturnErrors(string name,string lastname)
        {
            AddAuthorCommand command = new AddAuthorCommand(null, null);
            command.Model = new AddAuthorViewModel
            {
                Name = name,
                LastName = lastname,
                BirthDate = DateTime.Now.AddYears(-1)
            };

            CreateAuthorValidator validator = new CreateAuthorValidator();  
            var result= validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGivenCreateAuthor_Validator_ShouldBeReturnError()
        {
            AddAuthorCommand command = new AddAuthorCommand(null, null);
            command.Model = new AddAuthorViewModel
            {
                Name = "Jack",
                LastName = "Doe",
                BirthDate = DateTime.Now.Date
            };

            CreateAuthorValidator validator = new CreateAuthorValidator();
            var result= validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]  
        public void WhenValidInputsAreGivenCreateAuthor_Validator_ShouldNotBeReturnError()
        {
            AddAuthorCommand command = new AddAuthorCommand(null, null);
            command.Model = new AddAuthorViewModel
            {
                Name = "Jack",
                LastName = "Doe",
                BirthDate = DateTime.Now.Date.AddYears(-2)
            };

            CreateAuthorValidator validator = new CreateAuthorValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
