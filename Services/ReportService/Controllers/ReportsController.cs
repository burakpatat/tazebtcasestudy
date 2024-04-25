
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Application.Mediator.Queries;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetFormReportList()
        {
            var FormFieldsValue = await _mediator.Send(new GetFormFieldValuesQuery());
            var FormFields = await _mediator.Send(new GetFormFieldsQuery());
            var Form = await _mediator.Send(new GetFormQuery());

            foreach (var item in Form)
            {
                var _fields = FormFields.Where(x => x.FormId == item.Id).ToList();
                item.FormFields = _fields;
                foreach (var field in item.FormFields)
                {
                    var formFieldValList = FormFieldsValue.Where(x => x.FormFieldId == field.Id).ToList();
                    field.FormFieldValues = formFieldValList;
                }
            }
            

            return Ok(Form);
        }
    }
}
