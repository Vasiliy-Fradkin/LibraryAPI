using Library.Domain.Interfaces;
using Library.Domain.Entities;
using MediatR;
using Library.Application.DTO;

namespace Library.Application.Features.Books
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; }
        public string Author { get; }
        public int Year { get; }
        public string Description { get; }
        public string ShelfName { get; }

        public CreateBookCommand(CreateBookDto dto)
        {
            Title = dto.Title;
            Author = dto.Author;
            Year = dto.Year;
            Description = dto.Description;
            ShelfName = dto.ShelfName;
        }


    }
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _repository;
        public CreateBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Year = request.Year,
                Description = request.Description,
                ShelfName = request.ShelfName,
                DateAdded = DateTime.UtcNow
            };
            await _repository.AddBookAsync(book);
            return book.Id;
        }
    }
}
