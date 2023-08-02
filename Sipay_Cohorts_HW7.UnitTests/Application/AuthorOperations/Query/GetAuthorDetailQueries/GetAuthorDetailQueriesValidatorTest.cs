using FluentAssertions;
using Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Queries;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Queries;
using Sipay_Cohorts_HW7.Api.Validator.Author;
using Sipay_Cohorts_HW7.Api.Validator.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohorts_HW7.UnitTests.Application.AuthorOperations.Query.GetAuthorDetailQueries
{
    public class GetAuthorDetailQueriesValidatorTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenAuthorIdValueIsLessThanAndEqualZero_Validator_ShouldBeReturnErrors(int id)
        {
            GetByIdAuthorQuery query = new GetByIdAuthorQuery(null, null);
            query.Id = id;

            GetByIdAuthorValidation validator = new GetByIdAuthorValidation();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenAuthorIdValueIsMoreThanZero_Validator_ShouldNotBeReturnError()
        {
            GetByIdAuthorQuery query = new GetByIdAuthorQuery(null, null);
            query.Id = 1;

            GetByIdAuthorValidation validator = new GetByIdAuthorValidation();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);

        }
    }
}
