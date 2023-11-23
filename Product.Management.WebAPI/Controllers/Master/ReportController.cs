using Microsoft.AspNetCore.Mvc;
using Product.Management.BusinessLayer.Master;
using Product.Management.Common.Master;

namespace Product.Management.WebAPI.Controllers.Master
{

    [Route("api/Master/[controller]")]
    [ApiController]
    public class ReportController:ControllerBase
    {
        private ReportBL reportBL = null;
        [HttpGet]
        [Route("GetReportSaleOrder")]
        public ReportDataResponseModel GetReportSaleOrder([FromQuery] ReportDateRequestModel reportDateRequestModel)
        {
            reportBL = new ReportBL();
            return reportBL.GetResportSaleOrder(reportDateRequestModel);
           // return null;
        }
    }
}
