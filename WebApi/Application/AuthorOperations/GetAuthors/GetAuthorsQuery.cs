using AutoMapper;
using WebApi.Context;

namespace WebApi.Application.AuthorOperations.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var authors = _context.Authors;
            List<AuthorViewModel> returnObj = _mapper.Map<List<AuthorViewModel>>(authors);
            return returnObj;
        }
    }

    public class AuthorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
    }
}
