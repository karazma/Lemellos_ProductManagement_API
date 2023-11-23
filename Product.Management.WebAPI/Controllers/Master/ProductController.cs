using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Product.Management.BusinessLayer.Master;
using Product.Management.Common;
using Product.Management.Common.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Management.WebAPI.Controllers.Master
{
    [Route("api/Master/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductBL productBL;

        public ProductController(IConfiguration configuration)
        {
        }

        [HttpPost]
        [Route("PostProductData")]
        public ICoreResponse PostProductData(ProductInsertModel productInput)
        {
            productBL = new ProductBL();
            /*if (customerAccountData.IsValidToken)
            {*/
                return productBL.PostProductData(productInput);
            /*}
            else
                return new CoreResponse { Status = CoreResponseStatus.TokenInvalid, Message = "Invalid Token" };*/
        }

        [HttpPut]
        public ICoreResponse UpdateCustomerAccount(ProductUpdateModel productInput)
        {
            productBL = new ProductBL();
            return productBL.UpdateProductData(productInput);
            
        }

        [HttpDelete]
        public ICoreResponse DeleteCustomerAccount(ProductDeleteModel productInput)
        {
            productBL = new ProductBL();
            return productBL.DeleteProductData(productInput);
        }

        [HttpGet]
        [Route("GetProductDataCollection")]
        public ProductDataCollectionModel GetProductDataCollection([FromQuery] ProductDataCollectionGetModel productDataInput)
        {
            productBL = new ProductBL();
            return productBL.GetProductDataCollection(productDataInput);
        }

        [HttpGet]
        [Route("GetProductSellingDataCollection")]
        public ProductSellingDataCollectionModel GetProductSellingDataCollection([FromQuery] ProductSellingDataCollectionGetModel productDataInput)
        {
            productBL = new ProductBL();
            return productBL.GetProductSellingDataCollection(productDataInput);
            
        }

        [HttpPost]
        [Route("PostBulkProductData")]
        public ICoreResponse PostBulkProductData(ProductBulkUploadModel path)
        {
            productBL = new ProductBL();
            return productBL.PostBulkProductData(path);
        }


    }
}
