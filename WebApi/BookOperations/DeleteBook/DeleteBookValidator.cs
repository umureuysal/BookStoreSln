using FluentValidation;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookValidator:AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookValidator()
        {
            RuleFor(book => book.BookId).GreaterThan(0);
        }
    }
}
