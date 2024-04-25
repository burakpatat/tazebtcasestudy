using Shared.Application.Mediator.Results;

namespace WebApp.Services
{
    public interface IReportService
    {
        Task<List<GetFormQueryResult>> GetFormReportList();
    }
}
