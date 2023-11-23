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
    public class ProductTypeController : ControllerBase
    {
        ProductTypeBL productTypeBL = null;
        [HttpGet]
        [Route("GetProductTypeNameData")]
        public ProductTypeNameResponseModel GetProductTypeNameData([FromQuery] ProductTypeNameGetModel ProductTypeNameGetData)
        {
            productTypeBL = new ProductTypeBL();
            return productTypeBL.GetProductTypeNameData();
        }
    }
}
