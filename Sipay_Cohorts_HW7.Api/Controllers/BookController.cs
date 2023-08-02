using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands;
using Sipay_Cohorts_HW7.DataAccess.Context;
using Sipay_Cohorts_HW7.Entities.DbSets;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Sipay_Cohorts_HW7.Api.Applications.BookOperations.Queries.GetByIdQuery;
using static Sipay_Cohorts_HW7.Api.Applications.BookOperations.Commands.UpdateBookCommand;
using Sipay_Cohorts_HW7.Api.Applications.BookOperations.Queries;
using Sipay_Cohorts_HW7.Api.Validator.Book;

namespace Sipay_Cohorts_HW7.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public BookController(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBookQuery query = new GetBookQuery(_dbContext,_mapper);
            var books = query.Handle();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            GetByIdQuery query = new GetByIdQuery(_dbContext, _mapper);
            BooksViewModel result = new BooksViewModel();
            query.Id = id;

            GetByIdQueryValidator validator = new GetByIdQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateBook([FromBody] CreateBookModel book) 
        {
            CreateBookCommand command = new CreateBookCommand(_dbContext,_mapper);
            command.Model = book;

            CreateBookCommandValidator validation = new CreateBookCommandValidator();
            validation.ValidateAndThrow(command);
            command.Handle();

            return Ok(book);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_dbContext);
            command.Model = updatedBook;
            command.Id = id;

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_dbContext);
            command.Id = id;

            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
    }
}
