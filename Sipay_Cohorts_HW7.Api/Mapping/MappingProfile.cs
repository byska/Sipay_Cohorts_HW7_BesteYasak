using AutoMapper;
using Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Commands;
using Sipay_Cohorts_HW7.Api.Applications.AuthorOperations.Queries;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Queries;
using Sipay_Cohorts_HW7.Api.Applications.GenreOperations.Queries;
using Sipay_Cohorts_HW7.Entities.DbSets;
using static Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands.UpdateBookCommand;
using static Sipay_Cohorts_HW7.Api.Applications.BookOperations.Queries.GetByIdQuery;
using static Sipay_Cohorts_HW7.Api.Applications.GenreOperations.Queries.GetGenreQuery;

namespace Sipay_Cohorts_HW7.Api.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BooksViewModel>();
            CreateMap<UpdateBookModel, Book>();
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksModel>();


            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenresViewModel>();

            CreateMap<Author,AuthorViewModel>();
            CreateMap<AddAuthorViewModel, Author>();
            CreateMap<Author, AuthorDetailViewModel>();
        }
    }
}
