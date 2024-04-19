
using Form.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

namespace FormService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly FormDbContext _dbContext;

        public FormsController(IConfiguration configuration, FormDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet("createform")]
        public async Task<IActionResult> CreateForm()
        {
            var form = new Forms
            {
                Name = "yform",
                Description = "this is Yform.",
                Status = 1
            };
            _dbContext.Forms.Add(form);
            _dbContext.SaveChanges();

            List<string> fieldNames = new List<string>();
            fieldNames.Add("email");
            fieldNames.Add("password");

            foreach (var fieldName in fieldNames)
            {
                var formField = new FormFields { FormId = form.Id, FieldName = fieldName, FieldType = "text", IsRequired = true };
                _dbContext.FormFields.Add(formField);
            }

            _dbContext.SaveChanges();

            return Ok("Form created successfully.");
        }

        [HttpPost("addformdata")]
        public async Task<IActionResult> AddFormData(string formName, Dictionary<string, string> fieldData)
        {
            var dynamicForm = _dbContext.Forms.FirstOrDefault(f => f.Name == formName);

            if (dynamicForm == null)
            {
                return BadRequest("Form not found.");
            }

            foreach (var field in fieldData)
            {
                var formField = _dbContext.FormFields.FirstOrDefault(ff => ff.FieldName == field.Key);

                if (formField == null)
                {
                    return BadRequest($"Field '{field.Key}' not found in the form.");
                }

                var formFieldValue = new FormFieldValues { FormFieldId = formField.Id, Value = field.Value };
                _dbContext.FormFieldValues.Add(formFieldValue);
            }

            _dbContext.SaveChanges();

            return Ok("Form data added successfully.");
        }
    }
}
