using AutoMapper;
using WebApi.Context;

namespace WebApi.Application.GenreOperations.GetGenres
{
    public class GetGenresQuery
    {
        private readonly ApplicationDbContext _context;
        public readonly IMapper _mapper;
        public GetGenresQuery(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive == true);
            List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);
            return returnObj;
        }

        public class GenresViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
