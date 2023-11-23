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
    public class SaleStatusController : ControllerBase
    {
        SaleStatusBL saleStatusBL;
        [HttpGet]
        [Route("GetSaleStatusNameData")]
        public SaleStatusNameResponseModel GetSaleStatusNameData([FromQuery] SaleStatusNameGetModel SaleStatusNameInput)
        {
            saleStatusBL = new SaleStatusBL();
            return saleStatusBL.GetSaleStatusNameData(SaleStatusNameInput);

        }
    }
}
