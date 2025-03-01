using Library.Domain.Interfaces;
using MediatR;
using Library.Application.DTO;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.Features.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<GetBookByIdDto>
    {
        [Range(1, int.MaxValue, ErrorMessage = "Некорректный номер id")]
        public int Id { get; set; }

    }
}
