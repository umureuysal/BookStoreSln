using AutoMapper;
using WebApi.Context;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorModel Model { get; set; }
        public CreateAuthorCommand(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=>x.FirstName == Model.FirstName && x.LastName==Model.LastName && x.DateofBirth == Model.BirthDate);
            if (author is not null)
                throw new InvalidOperationException("Yazar kaydı zaten mevcut");

            //author = _mapper.Map<Author>(Model);
            author = new Author();
            author.FirstName = Model.FirstName;
            author.LastName = Model.LastName;
            author.DateofBirth = Model.BirthDate;

            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate{ get; set; }
    }
}
