using MediatR;
using Library.Application.Dto;
using Library.Domain.Interfaces;

namespace Library.Application.Features.Books.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<IEnumerable<GetAllBooksDto>>
    {
    }
}
