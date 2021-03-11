using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.ViewModel
{
    public class CustomerDTO
    {
         
        public string FirstName { set; get; }        
        public string LastName { set; get; }
        public string Address { get; set; }       
        public string Phone { get; set; }        
        public string Email { get; set; }
        public Guid CUstomerTypeID { get; set; } 
        public DateTime DateCreated { get; set; }
    }
}
