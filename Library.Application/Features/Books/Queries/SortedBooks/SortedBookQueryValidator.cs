using FluentValidation;

namespace Library.Application.Features.Books.Queries.SortedBooks
{
    public class SortedBookQueryValidator: AbstractValidator<SortedBooksQuery>
    {
        public SortedBookQueryValidator() 
        {
            RuleFor(x => x.SortBy)
                .Must(SortBy => Enum.IsDefined(typeof(SortedBooksQuery.SortKind), SortBy))
                .WithMessage("Недопустимый тип сортировки"); 
        }
    }
}
