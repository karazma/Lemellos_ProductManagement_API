using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.Common.Transaction
{
    public class SaleOrderInsertModel : UserToken
    {
        public string SaleOrderNumber { get; set; }
        public Decimal SaleBillAmount { get; set; } 
        public Guid SaleStatusId { get; set; }
        public string CustomerId { get; set; }    
        public string GuestName { get; set; }
        public Guid PaymentTypeId { get; set; } 
        public Guid PaymentStatusId { get; set; }
        public SaleOrderDetailInsertModel[] SaleOrderDetailInsertData { get; set; }
    }

    public class SaleOrderDetailInsertModel
    {
        public string ProductId { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductMRP { get; set; }
        public decimal ProductBillAmount { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductDiscountPercentage { get; set; }
        public decimal ProductDiscountAmount { get; set; }
    }

    public class SaleOrderUpdateModel : UserToken
    {
        public Guid SaleOrderId { get; set; }
        public Decimal SaleBillAmount { get; set; }       
        public Guid SaleStatusId { get; set; }
        public Guid CustomerId { get; set; }
        public string GuestName { get; set; }
        public Guid PaymentTypeId { get; set; }
        public Guid PaymentStatusId { get; set; }
        public SaleOrderDetailUpdateModel[] SaleOrderDetailUpdateData { get; set; }
    }

    public class SaleOrderDetailUpdateModel
    {
        public string SaleOrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductMRP { get; set; }
        public decimal ProductBillAmount { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductDiscountPercentage { get; set; }
        public decimal ProductDiscountAmount { get; set; }
    }

    public class SaleOrderPrintStatusModel:UserToken
    {
        public string SaleOrderId { get; set; }
        public bool IsPrinted { get; set; }
    }

    public class SaleOrderDeleteModel : UserToken
    {
        public Guid SaleOrderId { get; set; }
    }

    public class SalePendingOrderDataModel
    {
        private decimal _saleBillAmount;
        public Guid SaleOrderId { get; set; }
        public string SaleOrderNumber { get; set; }
        public decimal SaleBillAmount
        {
            get
            {
                return _saleBillAmount;
            }
            set
            {
                _saleBillAmount = Math.Round(value, 2);
            }
        }
        public Guid CustomerId { get; set; }
        public string GuestName { get; set; }
        public string SaleOrderDate { get; set; }
        public SalePendingOrderDetailDataModel[] SalePendingOrderDetailData { get; set; }
    }

    public class SalePendingOrderCollectionDataModel:CoreResponse
    {
        public SalePendingOrderDataModel[] SalePendingOrderData { get; set; }
    }

    public class SalePendingOrderGetModel:UserToken
    {

    }

    public class SaleOrderGetModel : UserToken
    {
        public string FromOrderDate { get; set; }
        public string ToOrderDate { get; set; }
    }

}
