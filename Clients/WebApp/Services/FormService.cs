using Shared;
using Shared.Application.Mediator.Results;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using WebApp.Extensions;

namespace WebApp.Services
{
    public class FormService : IFormService
    {
        private readonly HttpClient _httpClient;

        public FormService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FormResponse> CreateForm(FormRequest _formRequest)
        {
            var response = await _httpClient.PostGetResponseAsync<FormResponse, FormRequest>("/form/create-form", _formRequest);

            if (response.Successful)
            {
                return new FormResponse { Successful = true };
            }
            return new FormResponse { Successful = false };
        }
        public async Task<FormResponse> AddFormData(FormFieldRequest _formFieldRequest)
        {
            var response = await _httpClient.PostGetResponseAsync<FormResponse, FormFieldRequest>("/form/add-form", _formFieldRequest);

            if (response.Successful)
            {
                return new FormResponse { Successful = true };
            }
            return new FormResponse { Successful = false };
        }

        public async Task<List<GetFormQueryResult>> GetFormList()
        {
            var result = await _httpClient.GetAsync<List<GetFormQueryResult>>("/form");

            return result;
        }
    }
}
