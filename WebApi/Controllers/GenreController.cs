using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.CreateGenre;
using WebApi.Application.GenreOperations.DeleteGenre;
using WebApi.Application.GenreOperations.GetGenreDetails;
using WebApi.Application.GenreOperations.GetGenres;
using WebApi.Application.GenreOperations.UpdateGenre;
using WebApi.Context;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenresQuery genres = new GetGenresQuery(_context, _mapper);
            var obj = genres.Handle();
            return Ok(obj);
        }

        [HttpGet("id")]
        public ActionResult GetGenreDetails(int id)
        {
            GetGenreDetailsQuery query = new GetGenreDetailsQuery(_context, _mapper);
            query.GenreId = id;
            GetGenreDetailsValidator validations = new GetGenreDetailsValidator();
            validations.ValidateAndThrow(query);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult CreateGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = newGenre;

            CreateGenreValidator validations = new CreateGenreValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel genreModel)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.Model = genreModel;
            command.GenreId = id;

            UpdateGenreValidator validations = new UpdateGenreValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;
            DeleteGenreValidator validations = new DeleteGenreValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
