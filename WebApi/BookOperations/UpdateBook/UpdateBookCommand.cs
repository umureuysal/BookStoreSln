using WebApi.Context;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Booktoupdate { get; set; }
        public int BookId { get; set; }
        private readonly ApplicationDbContext _context;
        public UpdateBookCommand(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);

            if (book == null)
                throw new InvalidOperationException("Kitap bulunamadı.");

            book.GenreId = Booktoupdate.GenreId != default ? Booktoupdate.GenreId : book.GenreId;
            book.Title = Booktoupdate.Title != default ? Booktoupdate.Title : book.Title;
            book.PageCount = Booktoupdate.PageCount != default ? Booktoupdate.PageCount : book.PageCount;
            book.PublishDate = Booktoupdate.PublishDate != default ? Booktoupdate.PublishDate : book.PublishDate;

            _context.SaveChanges();


        }

        public class UpdateBookModel
        {
                public string Title { get; set; }
                public int PageCount { get; set; }
                public DateTime PublishDate { get; set; }
                public int GenreId { get; set; }
            
        }

    }
}
