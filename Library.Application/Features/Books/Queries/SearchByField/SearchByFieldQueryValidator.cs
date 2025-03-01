using FluentValidation;

namespace Library.Application.Features.Books.Queries.SearchByField
{
    public class SearchByFieldQueryValidator : AbstractValidator<SearchByFieldQuery>
    {
        public SearchByFieldQueryValidator()
        {
            RuleFor(x => x.Year)
                .GreaterThan(0).WithMessage("Год должен быть больше нуля");
            RuleFor(x => x)
                .Must(x => !string.IsNullOrEmpty(x.Title) || !string.IsNullOrEmpty(x.Author) || x.Year.HasValue)
                .WithMessage("Укажите хотя бы один параметр поиска");
        }
    }
}
