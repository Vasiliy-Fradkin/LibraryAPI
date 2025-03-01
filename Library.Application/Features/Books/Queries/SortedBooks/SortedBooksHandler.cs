using Library.Application.Dto;
using Library.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Queries.SortedBooks
{
    public class SortedBooksHandler : IRequestHandler<SortedBooksQuery, IEnumerable<SortedBooksDto>>
    {
        private readonly IBookRepository _repository;
        public SortedBooksHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<SortedBooksDto>> Handle(SortedBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAllBooksAsync();
            var dto = books.Select(b => new SortedBooksDto
            {
                Author = b.Author,
                Title = b.Title,
                DateAdded = b.DateAdded,
                ShelfName = b.ShelfName,
            });
            return request.SortBy switch
            {
                SortedBooksQuery.SortKind.ByShelfName => dto.OrderByDescending(b => b.ShelfName),
                SortedBooksQuery.SortKind.ByDateAdded => dto.OrderByDescending(b => b.DateAdded),
                _ => dto
            };

        }
    }
}
