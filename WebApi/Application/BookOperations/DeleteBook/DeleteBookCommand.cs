using WebApi.Context;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly ApplicationDbContext _context;
        public DeleteBookCommand(ApplicationDbContext context)
        {
            _context = context;
        }
        public int BookId { get; set; }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
