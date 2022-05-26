using FluentValidation;

namespace WebApi.Application.AuthorOperations.GetAuthorDetails
{
    public class GetAuthorDetailsValidator:AbstractValidator<GetAuthorDetailsQuery>
    {
        public GetAuthorDetailsValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThan(0);
        }
    }
}
