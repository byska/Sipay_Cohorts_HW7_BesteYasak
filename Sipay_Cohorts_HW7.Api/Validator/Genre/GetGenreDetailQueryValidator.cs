using FluentValidation;
using Sipay_Cohorts_HW7.Api.Applications.GenreOperations.Queries;

namespace Sipay_Cohorts_HW7.Api.Validator.Genre
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailsQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
