using Product.Management.Common.Master;
using Product.Management.DataAccessLayer.MariaDB.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.BusinessLayer.Master
{
    public class ReportBL
    {
        public ReportDataResponseModel GetResportSaleOrder(ReportDateRequestModel reportDataRequestModel)
        {
            ReportData reportData = new ReportData();
            return reportData.GetReportSaleOrder(reportDataRequestModel);
        }
    }
}
