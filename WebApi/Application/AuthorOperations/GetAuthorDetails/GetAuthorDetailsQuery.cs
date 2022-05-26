using AutoMapper;
using WebApi.Context;

namespace WebApi.Application.AuthorOperations.GetAuthorDetails
{
    public class GetAuthorDetailsQuery
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }
        public GetAuthorDetailsQuery(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=>x.Id==AuthorId);
            if (author is null)
                throw new InvalidOperationException("Yazar kaydı mevcut değil");

            return _mapper.Map<AuthorDetailModel>(author);
            
        }
    }

    public class AuthorDetailModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
    }
}
