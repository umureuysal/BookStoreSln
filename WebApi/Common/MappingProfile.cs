using AutoMapper;
using WebApi.Application.AuthorOperations.GetAuthorDetails;
using WebApi.Application.AuthorOperations.GetAuthors;
using WebApi.Application.GenreOperations.GetGenreDetails;
using WebApi.BookOperations.GetBooks;
using WebApi.Entities;
using static WebApi.Application.GenreOperations.GetGenres.GetGenresQuery;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBookDetails.GetBookDetailQuery;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailsModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest =>dest.Author, opt => opt.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName));
            //CreateMap<Book, BookDetailsModel>().ForMember(dest=>dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName)); ;
            //CreateMap<Book, BooksViewModel>().ForMember(dest=>dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailModel>();
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Author, AuthorDetailModel>();
        }
    }
}
