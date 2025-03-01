using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Library.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id книги должен быть больше нуля");
            RuleFor(x => x.Dto.Title)
                .MaximumLength(100).WithMessage("Название книги не может быть больше 100 символов");
            RuleFor(x => x.Dto.Author)
                .MaximumLength(100).WithMessage("Имя автора не может быть больше 100 символов");
            RuleFor(x => x.Dto.Year)
                .GreaterThan(0).WithMessage("Год должен быть больше нуля")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"Год не может быть больше настоящего {DateTime.Now.Year}");
            RuleFor(x => x.Dto.ShelfName)
                .MaximumLength(100).WithMessage("Название полки не может быть больше 100 символов");
            RuleFor(x => x.Dto.Description)
                .MaximumLength(250).WithMessage("Описание не может быть больше 250 символов");
        }
    }
}
