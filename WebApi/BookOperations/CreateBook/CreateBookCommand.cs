using AutoMapper;
using WebApi.Context;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommand(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book != null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut.");
            }

            book = _mapper.Map<Book>(Model); //new Book();
            //book.GenreId = Model.GenreId;
            //book.Title = Model.Title;
            //book.PageCount = Model.PageCount;
            //book.PublishDate = Model.PublishDate;
            
            _context.Books.Add(book);
            _context.SaveChanges();
        }


        public class CreateBookModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
            public int GenreId { get; set; }
        }
    }
}
