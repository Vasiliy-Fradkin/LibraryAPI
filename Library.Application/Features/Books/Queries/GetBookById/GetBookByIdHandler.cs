using Library.Application.DTO;
using Library.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Queries.GetBookById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, GetBookByIdDto>
    {
        private readonly IBookRepository _repository;
        public GetBookByIdHandler(IBookRepository repository)
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
