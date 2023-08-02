using FluentValidation;
using Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Queries;

namespace Sipay_Cohorts_HW7.Api.Validator.Author
{
    public class GetByIdAuthorValidation:AbstractValidator<GetByIdAuthorQuery>
    {
        public GetByIdAuthorValidation()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
