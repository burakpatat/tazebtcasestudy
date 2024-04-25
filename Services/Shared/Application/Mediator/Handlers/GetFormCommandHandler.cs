using MediatR;
using Shared.Application.Mediator.Queries;
using Shared.Application.Mediator.Results;
using System.Data;


namespace Shared.Application.Mediator.Handlers
{
    public class GetFormCommandHandler : IRequestHandler<GetFormQuery, List<GetFormQueryResult>>
    {
        private readonly IRepository<Forms> _repository;

        public GetFormCommandHandler(IRepository<Forms> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetFormQueryResult>> Handle(GetFormQuery request, CancellationToken token)
        {

            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFormQueryResult
            {
               Id = x.Id,
               Name = x.Name,
               Description = x.Description,
               Status = x.Status
            }).ToList();
        }
    }
}
