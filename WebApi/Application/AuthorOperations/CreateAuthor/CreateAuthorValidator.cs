using FluentValidation;

namespace WebApi.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.Model.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.LastName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.BirthDate).NotNull().LessThanOrEqualTo(DateTime.Now.Date);
        }
    }
}
