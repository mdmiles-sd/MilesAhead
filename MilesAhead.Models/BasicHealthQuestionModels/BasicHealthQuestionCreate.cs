using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Models
{
    public class BasicHealthQuestionCreate
    {
        public bool IsTakingMedication { get; set; }
        
        public bool IsDiabetic { get; set; }
        
        public bool IsSmoker { get; set; }
    }
}
