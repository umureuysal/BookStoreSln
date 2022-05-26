using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

namespace WebApi
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title{ get; set; }
        public int GenreId{ get; set; }
        public Genre Genre{ get; set; }
        public Author Author { get; set; }
        public int PageCount{ get; set; }
        public DateTime PublishDate{ get; set; }
    }
}
