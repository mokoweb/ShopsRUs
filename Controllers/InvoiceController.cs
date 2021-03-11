using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopsRUs.CommonClasses;
using ShopsRUs.Data;
using ShopsRUs.Model;
using ShopsRUs.ViewModel;

namespace ShopsRUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ShopsRUsContext _context;

        public InvoiceController(ShopsRUsContext context)
        {
            _context = context;
        }


        // GET: api/Invoices/5
        [HttpPost("GetTotalInvoiceAmount")]
        public async Task<IActionResult> GetTotalInvoiceAmount(InvoiceDTO Bill)
        {

            //use customer type to get the discount by customer
            var customerDetails = _context.Customer.Where(x => x.Id == Bill.CustomerId).FirstOrDefault();
            if (customerDetails != null)
            {
                if (customerDetails.CustomerType.Name == HardCodes.CustomerTypeCodes.Customer && customerDetails.DateCreated.AddYears(2) > DateTime.Now)
                {
                    return Ok(Bill.TotalAmount);
                }

                var discount = _context.Discount.Where(c => c.CustomerTypeId == customerDetails.CUstomerTypeID).FirstOrDefault();

                if (discount != null )
                {              

                    //if the customer has spent upto 2 years
                    if (customerDetails.CustomerType.Name == HardCodes.CustomerTypeCodes.Customer && customerDetails.DateCreated.AddYears(2) <= DateTime.Now)
                    {
                        var balanceDue = Bill.TotalAmount - (discount.Value * Bill.TotalAmount);

                        return Ok(balanceDue);
                    }
                    else
                    {
                        var balanceDue = Bill.TotalAmount - ((discount.Value *  Bill.TotalAmount) / Convert.ToDecimal(discount.Key));

                        return Ok(balanceDue);

                    }
                }
            }

            return Ok(Bill.TotalAmount);
        }


      
    }
}
