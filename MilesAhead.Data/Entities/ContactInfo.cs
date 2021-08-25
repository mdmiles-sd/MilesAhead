using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Data
{
    public enum BestTimeToCall
    {
        Morning = 1,
        Afternoon,
        Evening 
    }
    public class ContactInfo
    {
        [Key]
        public int ContactInfoID { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public BestTimeToCall BestTimeToCall { get; set; }
    }
}

