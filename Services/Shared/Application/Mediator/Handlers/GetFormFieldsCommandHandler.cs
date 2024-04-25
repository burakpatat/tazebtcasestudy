using MediatR;
using Shared.Application.Mediator.Queries;
using Shared.Application.Mediator.Results;

namespace Shared.Application.Mediator.Handlers
{
    public class GetFormFieldsCommandHandler : IRequestHandler<GetFormFieldsQuery, List<GetFormFieldsQueryResult>>
    {
        private readonly IRepository<FormFields> _repository;

        public GetFormFieldsCommandHandler(IRepository<FormFields> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetFormFieldsQueryResult>> Handle(GetFormFieldsQuery request, CancellationToken token)
        {
            var FormFieldsValues = await _repository.GetAllAsync();
            return FormFieldsValues.Select(x => new GetFormFieldsQueryResult
            {
                Id = x.Id,
                FormId = x.FormId,
                FieldName = x.FieldName,
                FieldType = x.FieldType,
                IsRequired = x.IsRequired
            }).ToList();
        }
    }
}
