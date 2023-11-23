using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.Common.Master
{
    public class ProductInsertModel : UserToken
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Guid ProductTypeId { get; set; }
        public decimal MRP { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string BarcodeId { get; set; }
        public Guid BrandId { get; set; }
        public Guid VendorId { get; set; }
        public Int64 TotalCount { get; set; }
        public string ProductImagePath { get; set; }
        public bool IsActive { get; set; }
        public int gst { get; set; }
    }

    public class ProductUpdateModel : UserToken
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Guid ProductTypeId { get; set; }
        public decimal MRP { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string BarcodeId { get; set; }
        public Guid BrandId { get; set; }
        public Guid VendorId { get; set; }
        public Int64 TotalCount { get; set; }
        public string ProductImagePath { get; set; }
        public bool IsActive { get; set; }
    }

    public class ProductDeleteModel : UserToken
    {
        public Guid ProductId { get; set; }
    }

    public class ProductDataModel : CoreData
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Guid ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal MRP { get; set; }
        public decimal SellingPrice { get; set; }
        public string BarcodeId { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public Guid VendorId { get; set; }
        public string VendorName { get; set; }
        public Int64 TotalCount { get; set; }
        public Int64 AvailableStock { get; set; }
        public Int64 SoldCount { get; set; }
        public string ProductImagePath { get; set; }
    }

    public class ProductSellingDataModel
    {
        private decimal _sellingPrice;
        private string _mrp;
        private decimal _discountPercentage;
        public Guid ProductId { get; set; }
        public string BarcodeId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal SellingPrice
        {
            get
            {
                return _sellingPrice;
            }
            set
            {
                _sellingPrice = Math.Round(value, 2);
            }
        }
        public string MRP
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
        public decimal DiscountPercentage
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
        public Int64 AvailableStock { get; set; }
        public string ProductImagePath { get; set; }
    }

    public class ProductDataPagingModel
    {
        public int TotalPageCount { get; set; }
        public int TotalRecordCount { get; set; }
        public int StartRowNumber { get; set; }
        public int EndRowNumber { get; set; }
    }

    public class ProductDataCollectionModel:CoreResponse
    {
        public ProductDataModel[] ProductData { get; set; }
        public ProductDataPagingModel ProductDataPaging { get; set; }
    }

    public class ProductSellingDataCollectionModel : CoreResponse
    {
        public ProductSellingDataModel[] ProductSellingData { get; set; }
    }

    public class ProductNameGetModel:UserToken
    {
    }
    public class ProductDataCollectionGetModel:UserToken
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchText { get; set; }
    }
    public class ProductSellingDataCollectionGetModel : UserToken
    {
        public string SearchText { get; set; }
    }

    public class ProductBulkUploadModel : UserToken
    {
        public String FilePath { get; set; }
    }
}
