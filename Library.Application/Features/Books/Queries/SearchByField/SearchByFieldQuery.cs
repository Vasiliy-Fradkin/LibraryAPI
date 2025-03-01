using Library.Application.Dto;
using Library.Domain.Interfaces;
using MediatR;

namespace Library.Application.Features.Books.Queries.SearchByField
{
    public class SearchByFieldQuery : IRequest<IEnumerable<SearchByFieldDto>>
    {
        public string? Title { get; }
        public string? Author { get; }
        public int? Year { get; }
    };
}

