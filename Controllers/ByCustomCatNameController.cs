using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SLB.Data;
using SLB.Models;

namespace SLB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ByCustomCatNameController : ControllerBase
    {
        private readonly ILogger<ByCustomCatNameController> _logger;

        public ByCustomCatNameController(ILogger<ByCustomCatNameController> logger)
        {
            _logger = logger;
        }
        List<Customer> customers = new List<Customer>();

        [HttpGet("{customerCategoryName}")]
        public List<Customer> Get(string customerCategoryName)
        {
            try
            {
                List<Customer> requestedData = new List<Customer>();
                QueryByCustomerCatName query = new QueryByCustomerCatName();
                requestedData = query.SelectDataByCustomerCatName(customerCategoryName);

                return requestedData;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("ERROR: ", Convert.ToString(ex.Message));
            }
        }
    }
}
