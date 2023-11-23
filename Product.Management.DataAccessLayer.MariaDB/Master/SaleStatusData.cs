using Product.Management.Common;
using Product.Management.Common.MariaDataAccess;
using Product.Management.Common.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Product.Management.DataAccessLayer.MariaDB.Master
{
    public class SaleStatusData
    {
        private string ConnectionString = DBContext.Instance.ConnectionString;
        public SaleStatusNameResponseModel GetSaleStatusNameData()
        {
            DBCommand dbCommand = null;
            SaleStatusNameResponseModel saleStatusNameResponse = new SaleStatusNameResponseModel();
            int outVal = Constants.MINUSTWO;

            try
            {
                DataSet ds = new DataSet();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                ds = dbCommand.ExecuteCommand("Master_SaleStatusName_Get");
                if (ds?.Tables.Count == Constants.ONE && ds.Tables[0].Rows.Count > Constants.ZERO)
                {
                    ICoreData coreData = new CoreData();
                    saleStatusNameResponse.SaleStatusNameData = coreData.ConvertToList<SaleStatusNameDataModel>(ds.Tables[0]);
                    saleStatusNameResponse.Status = CoreResponseStatus.Success;
                    saleStatusNameResponse.Message = "Data available";
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

            return outVal == Constants.ONE ? saleStatusNameResponse : new Common().GetCoreResponse<SaleStatusNameResponseModel>(outVal);
        }
    }
}
