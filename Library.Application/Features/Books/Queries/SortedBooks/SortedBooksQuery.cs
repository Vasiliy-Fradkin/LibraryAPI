using MediatR;
using Library.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Interfaces;

namespace Library.Application.Features.Books.Queries.SortedBooks
{
    public class SortedBooksQuery : IRequest<IEnumerable<SortedBooksDto>>
    {
        public SortKind SortBy { get; set; }
        public enum SortKind
        {
            ByShelfName,
            ByDateAdded
        }
    }
}
