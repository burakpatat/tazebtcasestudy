using MediatR;
using Shared.Application.Mediator.Results;

namespace Shared.Application.Mediator.Queries
{
    public class GetFormQuery : IRequest<List<GetFormQueryResult>>
    {

    }
}
