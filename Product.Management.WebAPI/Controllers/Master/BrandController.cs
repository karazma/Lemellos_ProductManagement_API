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
    public class BrandController : ControllerBase
    {
        BrandBL brandBL = null;
        [HttpGet]
        [Route("GetBrandNameData")]
        public BrandNameResponseModel GetBrandNameData([FromQuery] BrandNameGetModel brandNameGetData)
        {
            brandBL = new BrandBL();
            return brandBL.GetBrandNameData();
        }
    }
}
