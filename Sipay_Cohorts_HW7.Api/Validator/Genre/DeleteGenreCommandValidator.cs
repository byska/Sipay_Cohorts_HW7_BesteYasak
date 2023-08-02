using FluentValidation;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands;
using Sipay_Cohorts_HW7.Api.Applications.GenreOperations.Commands;

namespace Sipay_Cohorts_HW7.Api.Validator.Genre
{
    public class DeleteGenreCommandValidator:AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x=>x.Id).GreaterThan(0);    
        }
    }
}
