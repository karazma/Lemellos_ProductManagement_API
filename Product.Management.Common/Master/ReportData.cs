using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.Common.Master
{

    public class ReportSaleOrderModel : UserToken
    {
        public string SaleOrderNumber { get; set; }
        public string GuestName { get; set; }
        public string ProductName { get; set; }
        public string ProductBillAmount { get; set; }
        public string BuyingPrice { get; set; }
        public string SaleDate { get; set; }

    }

    public class ReportDataResponseModel : CoreResponse
    {
        public ReportSaleOrderModel[] ReportSaleOrderData { get; set; }

    }

    public class ReportDataResponseModelGet : UserToken
    {
       
    }

    public class ReportDateRequestModel {
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string reportType { get; set; }
    }
}
