using Library.Domain.Interfaces;
using Library.Domain.Entities;
using MediatR;
using FluentValidation;
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

    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required");
            RuleFor(x => x.Year).InclusiveBetween(1000, DateTime.UtcNow.Year)
                .WithMessage($"Year must be between 1000 and {DateTime.UtcNow.Year}");
            RuleFor(x => x.ShelfName).NotEmpty().WithMessage("ShelfName is required");
        }
    }

}
