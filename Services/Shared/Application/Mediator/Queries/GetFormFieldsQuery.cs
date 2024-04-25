
using MediatR;
using Shared.Application.Mediator.Results;

namespace Shared.Application.Mediator.Queries
{
    public class GetFormFieldsQuery : IRequest<List<GetFormFieldsQueryResult>>
    {

    }
}
