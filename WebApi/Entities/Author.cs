using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Author
    {
        [Key]
        public int Id{ get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public DateTime DateofBirth{ get; set; }
    }
}
