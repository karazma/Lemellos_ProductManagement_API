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
    public class PaymentStatusController : ControllerBase
    {
        PaymentStatusBL paymentStatusBL;
        [HttpGet]
        [Route("GetPaymentStatusNameData")]
        public PaymentStatusNameResponseModel GetPaymentStatusNameData([FromQuery] PaymentStatusNameDataGetModel paymentStatusNameDataInput)
        {
            paymentStatusBL = new PaymentStatusBL();
            return paymentStatusBL.GetPaymentStatusNameData(paymentStatusNameDataInput);

        }
    }
}
