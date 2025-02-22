using Library.Domain.Interfaces;
using Library.Domain.Entities;
using MediatR;
using FluentValidation;
using Library.Application.DTO;

namespace Library.Application.Features.Books
{
    public class GetBookByIdQuery : IRequest<GetBookByIdDto>
    {
        public int Id { get; set; }

    }
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, GetBookByIdDto>
    {
        private readonly IBookRepository _repository;
        public GetBookByIdQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetBookByIdDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetBookByIdAsync(request.Id);
            if (book == null) return null;
            var dto = new GetBookByIdDto
            {
                
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
                Description = book.Description,
                ShelfName = book.ShelfName,
                DateAdded = book.DateAdded
            };
            
            return dto;
        }
    }

    

}
