using FluentValidation;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookValidator: AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookValidator()
        {
            RuleFor(command => command.Booktoupdate.GenreId).NotEmpty().WithMessage("Genre Id boş olamaz.");
            RuleFor(command => command.Booktoupdate.PageCount).NotEmpty().WithMessage("Page Count boş olamaz.");
            RuleFor(command => command.Booktoupdate.PublishDate).NotEmpty().WithMessage("Publish Date boş olamaz.");
            RuleFor(command => command.Booktoupdate.Title).NotEmpty().WithMessage("Title boş olamaz.");
            RuleFor(command => command.Booktoupdate.Title).Must(StartWithA).WithMessage("Title, 'A' ile başlamalıdır.");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
