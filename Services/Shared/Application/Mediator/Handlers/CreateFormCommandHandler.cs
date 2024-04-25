using MediatR;
using Shared.Application.Mediator.Commands;

namespace Shared.Application.Mediator.Handlers
{
    public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand>
    {
        private readonly IRepository<Forms> _repository;

        public CreateFormCommandHandler(IRepository<Forms> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateFormCommand request, CancellationToken token)
        {
            await _repository.CreateAsync(new Forms
            {
                Name = request.Name,
                Description = request.Description,
                Status = request.Status,
                FormFields = request.FormFields
            });
        }
    }
}
