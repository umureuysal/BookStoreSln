using FluentValidation;

namespace WebApi.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(x => x.Model.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.LastName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.Birthdate).NotNull().LessThanOrEqualTo(DateTime.Now.Date);
        }
    }
}
