using Library.Application.Dto;
using Library.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Books
{
    public class UpdateBookCommand : IRequest<UpdateBookDto>
    {
        public int Id { get; set; }
        public UpdateBookDto Dto { get; set; }
        public UpdateBookCommand(int id, UpdateBookDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }

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

            book.Title = request.Dto.Title;
            book.Description = request.Dto.Description;
            book.Author = request.Dto.Author;
            book.ShelfName = request.Dto.ShelfName;
            book.Year = request.Dto.Year;

            await _repository.UpdateBookAsync(book);
            return request.Dto;

        }
    }

}
