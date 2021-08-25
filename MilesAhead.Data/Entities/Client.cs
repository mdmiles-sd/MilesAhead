using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Data
{
    public enum Sex
    {
        Male = 1,
        Female
    }

    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public float Height { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public Sex Sex { get; set; }
        [Required]
        public DateTimeOffset InitalCreateUTC { get; set; }
        public DateTimeOffset? EditUTC { get; set; }

        [ForeignKey("ContactInfo")]
        public int? ContactInfoID { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }

        [ForeignKey("BasicHealthQuestion")]
        public int? BasicHealthQuestionID { get; set; }
        public virtual BasicHealthQuestion BasicHealthQuestion { get; set; }

        [ForeignKey("Beneficiary")]
        public int? BeneficiaryID { get; set; }
        public virtual Beneficiary Beneficiary { get; set; }
    }
}
