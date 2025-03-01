using FluentValidation;

namespace Library.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator: AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Обязательное поле.");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Обязательное поле.");

            RuleFor(x => x.Year)
                .NotEmpty().WithMessage("Обязательное поле")
                .GreaterThan(0).WithMessage("Год должен быть больше нуля")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"Год не может быть больше {DateTime.Now.Year}");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Обязательное поле");

            RuleFor(x => x.ShelfName)
                .NotEmpty().WithMessage("Обязательное поле");

        }
    }
}
