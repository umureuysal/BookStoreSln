using AutoMapper;
using WebApi.Context;

namespace WebApi.Application.GenreOperations.GetGenreDetails
{
    public class GetGenreDetailsQuery
    {
        public int GenreId { get; set; }
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreDetailsQuery(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive == true && x.Id == GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("Kayıt bulunamadı.");
            }
            return _mapper.Map<GenreDetailModel>(genre);
        }
    }

    public class GenreDetailModel
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
    }
}
