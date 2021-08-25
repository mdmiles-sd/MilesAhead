using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Data
{
    public enum Relationship
    {
        Spouse = 1,
        Father,
        Mother,
        Son,
        Daughter,
        Aunt,
        Uncle,
        Neice,
        Nephew,
        Cousin,
        Freind
    }
    public class Beneficiary
    {
        [Key]
        public int BeneficiaryID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Relationship Relationship { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
    }
}
