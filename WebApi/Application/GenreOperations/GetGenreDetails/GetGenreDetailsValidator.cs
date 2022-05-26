using FluentValidation;

namespace WebApi.Application.GenreOperations.GetGenreDetails
{
    public class GetGenreDetailsValidator : AbstractValidator<GetGenreDetailsQuery>
    {
        public GetGenreDetailsValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);
        }
        
    }
}
