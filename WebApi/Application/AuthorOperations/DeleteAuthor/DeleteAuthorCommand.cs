using WebApi.Context;

namespace WebApi.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly ApplicationDbContext _context;
        public int AuthorId { get; set; }
        public DeleteAuthorCommand(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Yazar kaydı bulunamadı.");

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
