using FluentValidation;

namespace WebApi.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreValidator :AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreValidator()
        {
            RuleFor(x => x.GenreId).NotNull().GreaterThan(0); ;
        }
    }
}
