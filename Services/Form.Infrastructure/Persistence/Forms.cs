using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form.Infrastructure.Persistence
{
    public class Forms : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

    }
}
