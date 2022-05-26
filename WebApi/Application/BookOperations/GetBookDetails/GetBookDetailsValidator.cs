using FluentValidation;

namespace WebApi.BookOperations.GetBookDetails
{
    public class GetBookDetailsValidator:AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailsValidator()
        {
            RuleFor(command => command.BookId).NotEmpty().WithMessage("Book Id boş olamaz.");
        }
    }
}
