using MilesAhead.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Models.ContactInfoModels
{
    class ContactInfoDetail
    {        
        public int ContactInfoID { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public int ZipCode { get; set; }
        
        public string Email { get; set; }
        
        public int PhoneNumber { get; set; }
        
        public BestTimeToCall BestTimeToCall { get; set; }
    }
}
