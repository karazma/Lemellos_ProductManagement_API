using Product.Management.Common;
using Product.Management.Common.MariaDataAccess;
using Product.Management.Common.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Product.Management.DataAccessLayer.MariaDB.Master
{
    public class PaymentStatusData
    {
        private string ConnectionString = DBContext.Instance.ConnectionString;
        public PaymentStatusNameResponseModel GetPaymentStatusNameData()
        {
            DBCommand dbCommand = null;
            PaymentStatusNameResponseModel paymentStatusNameResponse = new PaymentStatusNameResponseModel();
            int outVal = Constants.MINUSTWO;

            try
            {
                DataSet ds = new DataSet();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                ds = dbCommand.ExecuteCommand("Master_PaymentStatusName_Get");
                if (ds?.Tables.Count == Constants.ONE && ds.Tables[0].Rows.Count > Constants.ZERO)
                {
                    ICoreData coreData = new CoreData();
                    paymentStatusNameResponse.PaymentStatusNameData = coreData.ConvertToList<PaymentStatusNameDataModel>(ds.Tables[0]);
                    paymentStatusNameResponse.Status = CoreResponseStatus.Success;
                    paymentStatusNameResponse.Message = "Data available";
                    outVal = Constants.ONE;
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

            return outVal == Constants.ONE ? paymentStatusNameResponse : new Common().GetCoreResponse<PaymentStatusNameResponseModel>(outVal);
        }
    }
}
