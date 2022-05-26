using WebApi.Context;

namespace WebApi.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly ApplicationDbContext _context;
        public DeleteGenreCommand(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Kayıt bulunamadı.");

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}
