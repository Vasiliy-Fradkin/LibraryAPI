using MediatR;
using Library.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Interfaces;

namespace Library.Application.Features.Books
{
    public class GetAllBooksQuery : IRequest<IEnumerable<GetAllBooksDto>>
    {
    }

    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<GetAllBooksDto>>
    {
        private readonly IBookRepository _repository;
        public GetAllBooksQueryHandler(IBookRepository repository)
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
