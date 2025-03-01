using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Library.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandValidator: AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator() 
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Значение id должно быть больше нуля");
        }
    }
}
