using MilesAhead.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Models.BeneficiaryModels
{
    class BeneficiaryEdit
    {        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public Relationship Relationship { get; set; }
        
        public int PhoneNumber { get; set; }
    }
}
