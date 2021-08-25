using MilesAhead.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Models
{
    class InsurancePolicyCreate
    {
        public decimal CoverageAmount { get; set; }
        
        public TypeOfPolicy TypeOfPolicy { get; set; }

    }
}
