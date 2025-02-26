using Library.Application.Dto;
using Library.Application.DTO;
using Library.Application.Features.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid book data");

            var command = new CreateBookCommand(dto);
            var bookId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBookById), new { id = bookId }, new { id = bookId });
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid book data");

            var command = new UpdateBookCommand(id, dto);
            var updatedbook = await _mediator.Send(command);
            return Ok(updatedbook);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {

            var command = new DeleteBookCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromQuery]GetBookByIdQuery request)
        {
            var bookDto = await _mediator.Send(request);
            if (bookDto == null)
                return NotFound($"����� � id={request.Id} �� �������.");
            return Ok(bookDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var query = new GetAllBooksQuery { };
            var bookDto = await _mediator.Send(query);
            if (bookDto == null)
                return NotFound();
            return Ok(bookDto);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<SearchByFieldDto>> SearchByField([FromQuery] SearchByFieldQuery request)
        {   
            return await _mediator.Send(request); 
        }

        [HttpGet("sort")]
        public async Task<IEnumerable<SortedBooksDto>> SortedBooks([FromQuery]  SortedBooksQuery request)
        {
            return await _mediator.Send(request);
        }
    }
}
