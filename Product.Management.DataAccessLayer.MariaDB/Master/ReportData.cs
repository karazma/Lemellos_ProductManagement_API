using Product.Management.Common;
using Product.Management.Common.MariaDataAccess;
using Product.Management.Common.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Product.Management.DataAccessLayer.MariaDB.Master
{
    public class ReportData
    {
        private string ConnectionString = DBContext.Instance.ConnectionString;

        public ReportDataResponseModel GetReportSaleOrder(ReportDateRequestModel reportDateRequestModel)
        {
            DBCommand dbCommand = null;
            ReportDataResponseModel reportData = new ReportDataResponseModel();
            int outVal = Constants.MINUSTWO;

            try
            {
                DataSet ds = new DataSet();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                dbCommand.AddParameter("p_fromDate", DbType.String, reportDateRequestModel.fromDate);
                dbCommand.AddParameter("p_toDate", DbType.String, reportDateRequestModel.toDate);
                //dbCommand.AddParameter("@reportType", DbType.String, reportDateRequestModel.reportType);
                ds = dbCommand.ExecuteCommand("Report_SaleOrder_Get");
                if (ds?.Tables.Count > Constants.ZERO && ds.Tables[0].Rows.Count > Constants.ZERO)
                {
                    ICoreData coreData = new CoreData();
                    reportData.ReportSaleOrderData = coreData.ConvertToList<ReportSaleOrderModel>(ds.Tables[0]);
                    //var totalRecordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                    if (ds.Tables[0].Rows.Count > Constants.ZERO)
                    {
                        reportData.Status = CoreResponseStatus.Success;
                        reportData.Message = "Data available";
                        outVal = Constants.ONE;
                    }
                }
                else if (ds == null || ds.Tables.Count == Constants.ZERO)
                    outVal = Constants.MINUSONE;
                else
                    outVal = Constants.ZERO;
            }
            catch (Exception ex)
            {
                //Log.Error(Constants.SourceName, "CustomerAccountData->GetCustomerAccountDataCollection", ex);
            }
            finally
            {
                if (dbCommand != null)
                    dbCommand.Dispose();
            }

            return outVal == Constants.ONE ? reportData : new Common().GetCoreResponse<ReportDataResponseModel>(outVal);
        }
    }
}
