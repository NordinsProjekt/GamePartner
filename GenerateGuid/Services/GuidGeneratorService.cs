using GenerateGuid.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateGuid.Services
{
    public class GuidGeneratorService : IGuidGeneratorService
    {
        public GuidGeneratorService() { }

        public Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }
    }
}
