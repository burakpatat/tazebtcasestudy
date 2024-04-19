using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form.Infrastructure.Persistence
{
    public class FormFieldValues : EntityBase<int>
    {
        public int FormFieldId { get; set; }
        public FormFields FormField { get; set; }
        public string Value { get; set; }
    }
}
