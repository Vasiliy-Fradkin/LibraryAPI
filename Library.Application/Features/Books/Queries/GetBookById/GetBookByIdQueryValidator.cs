using FluentValidation;

namespace Library.Application.Features.Books.Queries.GetBookById
{
    public class GetBookByIdValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Значение id должно быть больше нуля");
        }
    }
}