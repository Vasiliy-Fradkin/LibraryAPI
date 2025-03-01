using Library.Application.Dto;
using Library.Domain.Interfaces;
using MediatR;

namespace Library.Application.Features.Books.Queries.SearchByField
{
    public class SearchByFieldHandler : IRequestHandler<SearchByFieldQuery, IEnumerable<SearchByFieldDto>>
    {
        private readonly IBookRepository _repository;
        public SearchByFieldHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<SearchByFieldDto>> Handle(SearchByFieldQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAllBooksAsync();
            var result = books
            .Where(book => string.IsNullOrEmpty(request.Title) || book.Title == request.Title)
            .Where(book => string.IsNullOrEmpty(request.Author) || book.Author == request.Author)
            .Where(book => !request.Year.HasValue || book.Year == request.Year)
            .Select(book => new SearchByFieldDto()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
            });
            return result;
        }
    }
}
