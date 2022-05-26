using WebApi.Context;

namespace WebApi.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        private readonly ApplicationDbContext _context;
        public UpdateGenreCommand(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=>x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Kayıt bulunamadı.");

            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id == GenreId))
                throw new InvalidOperationException("Aynı isimde bir kitap türü mevcut.");

            genre.Name = string.IsNullOrEmpty(Model.Name.Trim())  ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
