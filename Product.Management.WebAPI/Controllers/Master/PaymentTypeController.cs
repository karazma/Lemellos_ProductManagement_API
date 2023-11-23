using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class PaymentTypeController : ControllerBase
    {
        PaymentTypeBL paymentTypeBL;
        [HttpGet]
        [Route("GetPaymentTypeNameData")]
        public PaymentTypeNameResponseModel GetPaymentTypeNameData([FromQuery] PaymentTypeNameDataGetModel paymentTypeNameDataInput)
        {
            paymentTypeBL = new PaymentTypeBL();
            return paymentTypeBL.GetPaymentStatusNameData(paymentTypeNameDataInput);

        }
    }
}
