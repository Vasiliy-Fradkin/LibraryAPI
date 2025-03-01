using Library.Application.Dto;
using Library.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, UpdateBookDto>
    {
        private readonly IBookRepository _repository;
        public UpdateBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<UpdateBookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetBookByIdAsync(request.Id);

            if (book == null)
            {
                throw new KeyNotFoundException($"Книга с ID {request.Id} не существует.");
            }

            if (!string.IsNullOrWhiteSpace(request.Dto.Title))
                book.Title = request.Dto.Title;
            if (!string.IsNullOrWhiteSpace(request.Dto.Description))
                book.Description = request.Dto.Description;
            if (!string.IsNullOrWhiteSpace(request.Dto.Author))
                book.Author = request.Dto.Author;
            if (!string.IsNullOrWhiteSpace(request.Dto.ShelfName))
                book.ShelfName = request.Dto.ShelfName;
            if (request.Dto.Year.HasValue)
                book.Year = request.Dto.Year.Value;

            await _repository.UpdateBookAsync(book);
            return request.Dto;

        }
    }
}
