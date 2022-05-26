using FluentValidation;

namespace WebApi.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(x => x.AuthorId).NotNull().GreaterThan(0);
        }
    }
}
