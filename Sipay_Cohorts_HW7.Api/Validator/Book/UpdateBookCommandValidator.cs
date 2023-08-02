using FluentValidation;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands;

using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands;

namespace Sipay_Cohorts_HW7.Api.Validator.Book
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).NotEmpty();
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);


        }
        
    }
}
