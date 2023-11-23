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
    public class VendorController : ControllerBase
    {
        VendorBL vendorBL = null;
        [HttpGet]
        [Route("GetVendorNameData")]
        public VendorNameResponseModel GetProductTypeNameData([FromQuery] VendorNameGetModel VendorNameGetData)
        {
            vendorBL = new VendorBL();
            return vendorBL.GetVendorNameData();
        }
    }
}
