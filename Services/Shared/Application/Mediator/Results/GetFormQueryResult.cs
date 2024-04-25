using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Application.Mediator.Results
{
    public class GetFormQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public List<GetFormFieldsQueryResult> FormFields { get; set; } = new List<GetFormFieldsQueryResult>();
    }
}
