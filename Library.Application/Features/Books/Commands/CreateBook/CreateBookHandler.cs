using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _repository;
        public CreateBookHandler(IBookRepository repository)
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
