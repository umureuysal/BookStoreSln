using WebApi.Common;
using WebApi.Context;

namespace WebApi.BookOperations.GetBookDetails
{
    public class GetBookDetailsCommand
    {
        public ApplicationDbContext _context;
        public int BookId { get; set; }

        public GetBookDetailsCommand(ApplicationDbContext context)
        {
            _context = context;
        }

        public BookDetailsModel Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            BookDetailsModel model = new BookDetailsModel();
            model.Title = book.Title;
            model.PageCount = book.PageCount;
            model.PublishDate = book.PublishDate.Date.ToString("dd-MM-yyy");
            model.Genre = ((GenreEnum)book.GenreId).ToString();
            return model;
        }

        public class BookDetailsModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }

    }
}
