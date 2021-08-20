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
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public BestTimeToCall BestTimeToCall { get; set; }
    }
}

