﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.ViewModel
{
    public class InvoiceDTO
    {            
            public Guid CustomerId { get; set; }           
            public decimal TotalAmount { get; set; }          
        
    }
}
