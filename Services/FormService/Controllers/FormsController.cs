
using Form.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Application.Mediator.Queries;

namespace FormService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly FormDbContext _dbContext;
        private readonly IMediator _mediator;

        public FormsController(IConfiguration configuration, FormDbContext dbContext, IMediator mediator)
        {
            _configuration = configuration;
            _dbContext = dbContext;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFormList()
        {
            var FormFields = await _mediator.Send(new GetFormFieldsQuery());
            var Form = await _mediator.Send(new GetFormQuery());

            foreach (var item in Form)
            {
                var _fields = FormFields.Where(x => x.FormId == item.Id).ToList();
                item.FormFields = _fields;
            }

            return Ok(Form);
        }

        [HttpPost("createform")]
        public async Task<IActionResult> CreateForm(FormRequest _formRequest)
        {
            var form = new Shared.Forms
            {
                Name = _formRequest.Name,
                Description = _formRequest.Description,
                Status = _formRequest.Status.ToInt()
            };
            _dbContext.Forms.Add(form);
            _dbContext.SaveChanges();

            List<string> fieldNames = new List<string>();
            for (int i = 0; i < _formRequest.FieldCount; i++)
            {
                fieldNames.Add(_formRequest.FormFields[i].FieldName);
            }

            for (int i = 0; i < fieldNames.Count; i++)
            {
                var formField = new Shared.FormFields { FormId = form.Id, FieldName = fieldNames[i], 
                    FieldType = _formRequest.FormFields[i].FieldType, IsRequired = _formRequest.FormFields[i].IsRequired };

                _dbContext.FormFields.Add(formField);
            }

            _dbContext.SaveChanges();

            return Ok(new FormResponse { Successful = true, Message = "Form created successfully" });
        }

        [HttpPost("addform")]
        public async Task<IActionResult> AddFormData(FormFieldRequest _formFieldRequest)
        {

            if (_formFieldRequest == null)
            {
                return BadRequest("_formFieldRequest is null.");
            }

            var dynamicForm = _dbContext.Forms.FirstOrDefault(f => f.Id == _formFieldRequest.FormId);

            if (dynamicForm == null)
            {
                return BadRequest("Form not found.");
            }

            Shared.FormFieldValues formFieldValue = new Shared.FormFieldValues();

            if (_formFieldRequest.IsCheckboxField)
            {
                foreach (var fieldBool in _formFieldRequest.BoolFieldValues)
                {
                    var formFieldBool = _dbContext.FormFields.FirstOrDefault(ff => ff.FieldName == fieldBool.Key);

                    if (formFieldBool == null)
                    {
                        return BadRequest($"Field '{formFieldBool.FieldName}' not found in the form.");
                    }
                    else
                    {
                        if (formFieldBool.FormId == _formFieldRequest.FormId)
                        {
                            formFieldValue = new Shared.FormFieldValues { FormFieldId = formFieldBool.Id, Value = fieldBool.Value.ToString().ToLowerInvariant() };
                        }
                    }
                }
            }
            else
            {
                foreach (var field in _formFieldRequest.FieldValues)
                {
                    var formField = _dbContext.FormFields.Where(ff => ff.FieldName == field.Key).ToList();

                    if (formField == null)
                    {
                        return BadRequest($"Field '{formField}' not found in the form.");
                    }
                    else
                    {
                        foreach (var item in formField)
                        {
                            if (item.FormId == _formFieldRequest.FormId)
                            {
                                formFieldValue = new Shared.FormFieldValues { FormFieldId = item.Id, Value = field.Value };
                                _dbContext.FormFieldValues.Add(formFieldValue);
                            }
                        }
                        
                    }
                }
            }
            
            _dbContext.SaveChanges();

            return Ok(new FormResponse { Successful = true, Message = "Form data added successfully" });
        }
    }
}
