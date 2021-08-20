using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Data
{
    public enum TypeOfPolicy
    {
        Term = 1,
        WholeLife
    }

    public class InsurancePolicy
    {
        [Key]
        public int InsurancePolicyID { get; set; }
        [Required]
        public decimal CoverageAmount { get; set; }
        public TypeOfPolicy TypeOfPolicy { get; set; }

        [ForeignKey("Client")]
        public int? ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}


