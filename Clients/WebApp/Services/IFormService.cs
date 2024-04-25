using Shared;
using Shared.Application.Mediator.Results;

namespace WebApp.Services
{
    public interface IFormService
    {
        Task<List<GetFormQueryResult>> GetFormList();
        Task<FormResponse> CreateForm(FormRequest _formRequest);
        Task<FormResponse> AddFormData(FormFieldRequest _formFieldRequest);
    }
}
