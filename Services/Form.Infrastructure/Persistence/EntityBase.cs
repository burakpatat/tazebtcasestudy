﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form.Infrastructure.Persistence
{
    public class EntityBase<T>
    {
        public T Id { get; set; }
    }
}
