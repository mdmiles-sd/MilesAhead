using MilesAhead.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Models.InsurancePolicyModels
{
    class InsurancePolicyDetailList
    {        
        public int InsurancePolicyID { get; set; }
        
        public decimal CoverageAmount { get; set; }
        
        public TypeOfPolicy TypeOfPolicy { get; set; }

        public int ClientID { get; set; }
        
    }
}
