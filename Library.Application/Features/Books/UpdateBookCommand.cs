using Library.Application.Dto;
using Library.Domain.Interfaces;
using MediatR;

namespace Library.Application.Features.Books
{
    public class UpdateBookCommand : IRequest<UpdateBookDto>
    {
        public int Id { get; }
        public UpdateBookDto Dto { get; }
        public UpdateBookCommand(int id, UpdateBookDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }

    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, UpdateBookDto>
    {
        private readonly IBookRepository _repository;
        public UpdateBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<UpdateBookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetBookByIdAsync(request.Id);

            book.Title = request.Dto.Title;
            book.Description = request.Dto.Description;
            book.Author = request.Dto.Author;
            book.ShelfName = request.Dto.ShelfName;
            book.Year = request.Dto.Year;

            await _repository.UpdateBookAsync(book);
            return request.Dto;

        }
    }

}
