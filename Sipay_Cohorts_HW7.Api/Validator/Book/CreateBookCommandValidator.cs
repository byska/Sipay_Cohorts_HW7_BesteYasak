using FluentValidation;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands;

namespace Sipay_Cohorts_HW7.Api.Validator.Book
{
    public class CreateBookCommandValidator:AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Model.Title).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.GenreId).NotEmpty();
            RuleFor(x=>x.Model.PageCount).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(x => x.Model.AuthorId).NotEmpty();
        }
    }
}
