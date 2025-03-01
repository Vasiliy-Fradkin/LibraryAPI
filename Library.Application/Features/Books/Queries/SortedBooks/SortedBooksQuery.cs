using MediatR;
using Library.Application.Dto;
using System.Text.Json.Serialization;

namespace Library.Application.Features.Books.Queries.SortedBooks
{
    public class SortedBooksQuery : IRequest<IEnumerable<SortedBooksDto>>
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SortKind SortBy { get; set; }

        public enum SortKind
        {
            ByShelfName,
            ByDateAdded
        }
    }
}
