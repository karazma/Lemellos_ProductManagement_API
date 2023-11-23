using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using Product.Management.BusinessLayer.Master;
using Product.Management.Common.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Management.WebAPI.Controllers.Master
{
    [Route("api/Master/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerBL customerBL;

        [HttpGet]
        [Route("GetCustomerBillingData")]
        public CustomerBillingDataResponseModel GetCustomerBillingData([FromQuery] CustomerBillingDataGetModel customerBillingDataInput)
        {
            customerBL = new CustomerBL();
            return customerBL.GetCustomerBillingData();
        }

        [HttpGet]
        [Route("GetCustomerData")]
        public CustomerBillingDataResponseModel GetCustomerData([FromQuery] CustomerBillingDataGetModel customerBillingDataInput)
        {
            customerBL = new CustomerBL();
            return customerBL.GetCustomerData(customerBillingDataInput);
        }

        [HttpPost]
        [Route("InsertCustomerData")]
        public CustomerBillingDataResponseModel InsertCustomerData([FromBody] CustomerDataModel customerDataInput)
        {
            customerBL = new CustomerBL();
            return customerBL.InsertCustomerData(customerDataInput);
        }
    }
}
