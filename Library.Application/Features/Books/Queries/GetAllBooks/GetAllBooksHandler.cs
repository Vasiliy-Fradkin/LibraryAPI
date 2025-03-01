using Library.Application.Dto;
using Library.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Queries.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<GetAllBooksDto>>
    {
        private readonly IBookRepository _repository;
        public GetAllBooksHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetAllBooksDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAllBooksAsync();
            var bookDtos = books.Select(book => new GetAllBooksDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
            });
            return bookDtos;
        }
    }
}
