using AutoMapper;
using System.Collections.Generic;
using WebApi.Common;
using WebApi.Context;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksQuery(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var booklist = _context.Books.ToList();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(booklist);
                
                //new List<BooksViewModel>();
            //foreach (var book in booklist)
            //{
            //    vm.Add(new BooksViewModel()
            //    {
            //        Title = book.Title,
            //        PageCount = book.PageCount,
            //        PublishDate = book.PublishDate.Date.ToString("dd-MM-yyy"),
            //        Genre=((GenreEnum)book.GenreId).ToString()
            //    }) ;
            //}
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
