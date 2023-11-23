using Product.Management.Common;
using Product.Management.Common.MariaDataAccess;
using Product.Management.Common.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Product.Management.DataAccessLayer.MariaDB.Master
{
    public class PaymentTypeData
    {
        private string ConnectionString = DBContext.Instance.ConnectionString;
        public PaymentTypeNameResponseModel GetPaymentTypeNameData()
        {
            DBCommand dbCommand = null;
            PaymentTypeNameResponseModel paymentTypeDataResponse = new PaymentTypeNameResponseModel();
            int outVal = Constants.MINUSTWO;

            try
            {
                DataSet ds = new DataSet();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                ds = dbCommand.ExecuteCommand("Master_PaymentTypeName_Get");
                if (ds?.Tables.Count == Constants.ONE && ds.Tables[0].Rows.Count > Constants.ZERO)
                {
                    ICoreData coreData = new CoreData();
                    paymentTypeDataResponse.PaymentTypeNameData = coreData.ConvertToList<PaymentTypeNameDataModel>(ds.Tables[0]);
                    paymentTypeDataResponse.Status = CoreResponseStatus.Success;
                    paymentTypeDataResponse.Message = "Data available";
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

            return outVal == Constants.ONE ? paymentTypeDataResponse : new Common().GetCoreResponse<PaymentTypeNameResponseModel>(outVal);
        }
    }
}
