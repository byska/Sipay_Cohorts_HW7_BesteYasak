using FluentValidation;
using Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Commands;

namespace Sipay_Cohorts_HW7.Api.Validator.Author
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(4).When(x => x.Model.Name.Trim() != string.Empty);
            RuleFor(x => x.Model.LastName).MinimumLength(4).When(x => x.Model.LastName.Trim() != string.Empty);
            RuleFor(x => x.Model.BirthDate).NotEmpty().LessThan(DateTime.Now.Date);

        }
    }
}
