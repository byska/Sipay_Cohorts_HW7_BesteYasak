using FluentAssertions;
using FluentValidation;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Queries;
using Sipay_Cohorts_HW7.Api.Validator.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohorts_HW7.UnitTests.Application.BookOperations.Query.GetBookDetailQueries
{
    public class GetBookDetailQueriesValidatorTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenIdValueIsLessThanAndEqualZero_Validator_ShouldBeReturnErrors(int id)
        {
            GetByIdQuery query = new GetByIdQuery(null,null);
            query.Id = id;

            GetByIdQueryValidator validator = new GetByIdQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenIdValueIsMoreThanZero_Validator_ShouldNotBeReturnError()
        {
            GetByIdQuery query = new GetByIdQuery(null, null);
            query.Id = 1;

            GetByIdQueryValidator validator = new GetByIdQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);

        }
    }
}
