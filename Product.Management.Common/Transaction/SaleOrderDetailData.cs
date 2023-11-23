using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.Common.Transaction
{
    public class SaleOrderDetailInsertDataModel:UserToken
    {
        public Guid SaleOrderId { get; set; }
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

    public class SaleOrderDetailUpdateDataModel : UserToken
    {
        public Guid SaleOrderId { get; set; }
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

    public class SalePendingOrderDetailDataModel
    {
        private string _mrp;
        private decimal _discountPercentage,_billAmount,_discountAmount,_price;
        public Guid SaleOrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice {
            get
            {
                return _price;
            }
            set
            {
                _price = Math.Round(value, 2);
            }
        }
        public string ProductMRP
        {
            get
            {
                return _mrp;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && Convert.ToDecimal(value) > 0)
                    _mrp = Math.Round(Convert.ToDecimal(value), 2).ToString();
                else
                    _mrp = value;
            }
        }
        public decimal ProductBillAmount
        {
            get
            {
                return _billAmount;
            }
            set
            {
                _billAmount = Math.Round(value, 2);
            }
        }
        public int ProductQuantity { get; set; }
        public decimal ProductDiscountPercentage
        {
            get
            {
                return _discountPercentage;
            }
            set
            {
                _discountPercentage = Math.Round(value, 2);
            }
        }
        public decimal ProductDiscountAmount
        {
            get
            {
                return _discountAmount;
            }
            set
            {
                _discountAmount = Math.Round(value, 2);
            }
        }
    }

    public class SalePendingOrderDetailSingleDataModel:CoreResponse
    {
        public SalePendingOrderDetailDataModel[] SalePendingOrderDetailData { get; set; }
    }

    public class SalePendingOrderDetailGetModel : UserToken
    {
        public Guid SaleOrderId { get; set; }
    }
}
