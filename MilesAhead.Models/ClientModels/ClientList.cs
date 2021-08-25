using MilesAhead.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Models.ClientModels
{
    class ClientList
    {        
        public int ClientID { get; set; }        
        public Guid OwnerID { get; set; }        
        public string FirstName { get; set; }        
        public string LastName { get; set; }        
        public DateTime BirthDate { get; set; }        
        public int Age { get; set; }        
        public Sex Sex { get; set; }        
        public DateTimeOffset InitalCreateUTC { get; set; }
           
    
        
    }
}

