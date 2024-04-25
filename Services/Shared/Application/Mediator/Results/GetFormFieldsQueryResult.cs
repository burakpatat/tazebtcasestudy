using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Application.Mediator.Results
{
    public class GetFormFieldsQueryResult
    {
        public int Id { get; set; }
        public Guid FormId { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool IsRequired { get; set; }
        public List<GetFormFieldValuesQueryResult> FormFieldValues { get; set; } 
    }
}
