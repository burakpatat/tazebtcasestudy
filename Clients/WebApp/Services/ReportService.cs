using Shared.Application.Mediator.Results;
using WebApp.Extensions;

namespace WebApp.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;

        public ReportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<GetFormQueryResult>> GetFormReportList()
        {
            var result = await _httpClient.GetAsync<List<GetFormQueryResult>>("/report");

            return result;
        }
    }
}
