using FluentValidation;
using Sipay_Cohorts_HW7.Api.Applications.GenreOperations.Commands;

namespace Sipay_Cohorts_HW7.Api.Validator.Genre
{
    public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(query => query.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}
