using FluentValidation;

namespace WebApi.BookOperations.GetBookDetails
{
    public class GetBookDetailsValidator:AbstractValidator<GetBookDetailsCommand>
    {
        public GetBookDetailsValidator()
        {
            RuleFor(command => command.BookId).NotEmpty().WithMessage("Book Id boş olamaz.");
        }
    }
}
