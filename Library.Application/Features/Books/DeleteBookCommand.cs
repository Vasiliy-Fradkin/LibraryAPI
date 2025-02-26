using Library.Domain.Interfaces;
using MediatR;

namespace Library.Application.Features.Books
{
    public class DeleteBookCommand: IRequest<Unit>
    {
        public int Id { get; }
        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _repository;
        public DeleteBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteBookAsync(request.Id);
            return Unit.Value;
        }

        
    }
}
