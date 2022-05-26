using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookDetails;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.Context;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBookDetails.GetBookDetailQuery;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailsModel result;
            try
            {
                GetBookDetailQuery bookdetail = new GetBookDetailQuery(_context, _mapper);
                bookdetail.BookId = id;
                GetBookDetailsValidator validations = new GetBookDetailsValidator();
                validations.ValidateAndThrow(bookdetail);
                result = bookdetail.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newbook)
        {
            CreateBookCommand cb = new CreateBookCommand(_context, _mapper);
            //try
            //{
                cb.Model = newbook;
                CreateBookValidator validations = new CreateBookValidator();
                validations.ValidateAndThrow(cb);
                cb.Handle();
            //    if (!result.IsValid)
            //        foreach (var item in result.Errors)
            //        {
            //            Console.WriteLine("Özellik" + item.PropertyName + " - Error Message: " + item.ErrorMessage);
            //        }
            //    else


            //}
            //catch (Exception ex)
            //{

            //    return BadRequest(ex.Message);
            //}

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                command.BookId = id;
                command.Booktoupdate = updatedBook;
                UpdateBookValidator validations = new UpdateBookValidator();
                validations.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookValidator validations = new DeleteBookValidator();
                validations.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


            //var book = _context.Books.SingleOrDefault(x => x.Id == id);

            //if (book is null)
            //    return BadRequest();

            //_context.Books.Remove(book);
            //_context.SaveChanges();
            return Ok();

        }
    }
}
