using MediatR;
using Shared.Application.Mediator.Queries;
using Shared.Application.Mediator.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Application.Mediator.Handlers
{
    public class GetFormFieldValuesCommandHandler : IRequestHandler<GetFormFieldValuesQuery, List<GetFormFieldValuesQueryResult>>
    {
        private readonly IRepository<FormFieldValues> _repository;

        public GetFormFieldValuesCommandHandler(IRepository<FormFieldValues> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetFormFieldValuesQueryResult>> Handle(GetFormFieldValuesQuery request, CancellationToken token)
        {
            var FormFieldsValues = await _repository.GetAllAsync();
            return FormFieldsValues.Select(x => new GetFormFieldValuesQueryResult
            {
                FormFieldId = x.FormFieldId,
                Value = x.Value
            }).ToList();
        }
    }
}
