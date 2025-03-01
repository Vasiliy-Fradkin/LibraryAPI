using Library.Application.Dto;
using Library.Domain.Interfaces;
using MediatR;

namespace Library.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<UpdateBookDto>
    {
        public int Id { get; }
        public UpdateBookDto Dto { get; }
        public UpdateBookCommand(int id, UpdateBookDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }
}
