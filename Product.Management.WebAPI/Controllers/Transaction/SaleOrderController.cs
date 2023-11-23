using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Product.Management.BusinessLayer.Transaction;
using Product.Management.Common;
using Product.Management.Common.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Management.WebAPI.Controllers.Transaction
{
    [Route("api/Transaction/[controller]")]
    [ApiController]
    public class SaleOrderController : ControllerBase
    {
        private SaleOrderBL saleorderBL;

        public SaleOrderController(IConfiguration configuration)
        {
        }

        [HttpPost]
        [Route("PostSaleOrderData")]
        public ICoreResponse PostSaleOrderData(SaleOrderInsertModel saleInput)
        {
            saleorderBL = new SaleOrderBL();           
            return saleorderBL.PostSaleOrderData(saleInput);           
        }

        [HttpPut]
        [Route("UpdateSaleOrderData")]
        public ICoreResponse UpdateSaleOrder(SaleOrderUpdateModel saleInput)
        {
            saleorderBL = new SaleOrderBL();
            return saleorderBL.UpdateSaleOrderData(saleInput);
        }

        [HttpPut]
        [Route("UpdateSaleOrderPrintStatus")]
        public ICoreResponse UpdateSaleOrderPrintStatus(SaleOrderPrintStatusModel saleInput)
        {
            saleorderBL = new SaleOrderBL();
            return saleorderBL.UpdateSaleOrderPrintStatus(saleInput);
        }

        [HttpDelete]
        public ICoreResponse DeleteSaleOrder(SaleOrderDeleteModel saleInput)
        {
            saleorderBL = new SaleOrderBL();
            return saleorderBL.DeleteSaleOrderData(saleInput);
        }

        [HttpGet]
        [Route("GetSalePendingOrderData")]
        public SalePendingOrderCollectionDataModel GetSalePendingOrderData([FromQuery] SalePendingOrderGetModel saleOrderInputData)
        {
            saleorderBL = new SaleOrderBL();
            return saleorderBL.GetSalePendingOrderData(saleOrderInputData);
        }

        [HttpGet]
        [Route("GetSaleOrderData")]
        public SalePendingOrderCollectionDataModel GetSaleOrderData([FromQuery] SaleOrderGetModel saleOrderInputData)
        {
            saleorderBL = new SaleOrderBL();
            return saleorderBL.GetSaleOrderData(saleOrderInputData);
        }
    }
}
