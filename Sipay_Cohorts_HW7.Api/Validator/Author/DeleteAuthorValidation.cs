using FluentValidation;
using Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Commands;

namespace Sipay_Cohorts_HW7.Api.Validator.Author
{
    public class DeleteAuthorValidation:AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidation()
        {
            RuleFor(x=>x.Id).GreaterThan(0);

        }
    }
}
