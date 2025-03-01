using MediatR;
using Library.Application.Dto;

namespace Library.Application.Features.Books.Commands.CreateBook
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
}
