using MediatR;
using Shared.Application.Mediator.Results;

namespace Shared.Application.Mediator.Queries
{
    public class GetFormFieldValuesQuery : IRequest<List<GetFormFieldValuesQueryResult>>
    {

    }
}
