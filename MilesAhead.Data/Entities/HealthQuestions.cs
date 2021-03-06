using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Data
{
    public class BasicHealthQuestion
    {
        [Key]
        public int BasicHealthQuestionID { get; set; }
        [Required]
        public bool IsTakingMedication { get; set; }
        [Required]
        public bool IsDiabetic { get; set; }
        [Required]
        public bool IsSmoker { get; set; }
    }
}
