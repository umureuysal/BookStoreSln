using WebApi.Context;

namespace WebApi.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly ApplicationDbContext _context;
        public UpdateAuthorModel Model;
        public int AuthorId { get; set; }
        public UpdateAuthorCommand(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("Yazar kaydı buluamadı.");

            author.FirstName = Model.FirstName != default ? Model.FirstName : author.FirstName;
            author.LastName = Model.LastName != default ? Model.LastName : author.LastName;
            author.DateofBirth = Model.Birthdate != default ? Model.Birthdate : author.DateofBirth;

            _context.SaveChanges();
        }
    }

    public class UpdateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
