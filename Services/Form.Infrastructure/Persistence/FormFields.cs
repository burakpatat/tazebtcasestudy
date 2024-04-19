using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form.Infrastructure.Persistence
{
    public class FormFields : EntityBase<int>
    {
        public Guid FormId { get; set; }
        public Forms Form { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool IsRequired { get; set; }
    }
}
