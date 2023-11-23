using Product.Management.Common;
using Product.Management.Common.Transaction;
using Product.Management.DataAccessLayer.MariaDB.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.BusinessLayer.Transaction
{
    public class SaleOrderBL
    {
        private SaleOrderData saleorderData;
        public SaleOrderBL()
        {

        }
        public ICoreResponse PostSaleOrderData(SaleOrderInsertModel saleorderInput)
        {
            saleorderData = new SaleOrderData();
            return saleorderData.PostSaleOrderData(saleorderInput);
        }

        public ICoreResponse UpdateSaleOrderData(SaleOrderUpdateModel saleorderInput)
        {
            saleorderData = new SaleOrderData();
            return saleorderData.UpdateSaleOrderData(saleorderInput);
        }

        public ICoreResponse UpdateSaleOrderPrintStatus(SaleOrderPrintStatusModel saleorderInput)
        {
            saleorderData = new SaleOrderData();
            return saleorderData.UpdateSaleOrderPrintStatus(saleorderInput);
        }

        public ICoreResponse DeleteSaleOrderData(SaleOrderDeleteModel saleorderInput)
        {
            saleorderData = new SaleOrderData();
            return saleorderData.DeleteSaleOrderData(saleorderInput);
        }

        public SalePendingOrderCollectionDataModel GetSalePendingOrderData(SalePendingOrderGetModel saleOrderInputData)
        {
            saleorderData = new SaleOrderData();
            return saleorderData.GetSalePendingOrderData(saleOrderInputData);
        }

        public SalePendingOrderCollectionDataModel GetSaleOrderData(SaleOrderGetModel saleOrderInputData)
        {
            saleorderData = new SaleOrderData();
            return saleorderData.GetSaleOrderData(saleOrderInputData);
        }
    }
}
