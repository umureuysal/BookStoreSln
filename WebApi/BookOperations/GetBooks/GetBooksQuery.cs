using WebApi.Common;
using WebApi.Context;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly ApplicationDbContext _context;

        public GetBooksQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BooksViewModel> Handle()
        {
            var booklist = _context.Books.ToList();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in booklist)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.Date.ToString("dd-MM-yyy"),
                    Genre=((GenreEnum)book.GenreId).ToString()
                }) ;
            }
            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
