using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.Context;

namespace WebApi.BookOperations.GetBookDetails
{
    public class GetBookDetailQuery
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetBookDetailQuery(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BookDetailsModel Handle()
        {
            var book = _context.Books.Include(x=>x.Genre).SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            BookDetailsModel model = _mapper.Map<BookDetailsModel>(book); //new BookDetailsModel();
            //model.Title = book.Title;
            //model.PageCount = book.PageCount;
            //model.PublishDate = book.PublishDate.Date.ToString("dd-MM-yyy");
            //model.Genre = ((GenreEnum)book.GenreId).ToString();
            return model;
        }

        public class BookDetailsModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
            public string Author { get; set; }
        }

    }
}
