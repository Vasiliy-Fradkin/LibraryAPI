using Library.Domain.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Unit>
    {
        public int Id { get; }

        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}
