﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Rules
{
    public interface IRequirement
    {
        public bool Validate(object obj);
    }
}
