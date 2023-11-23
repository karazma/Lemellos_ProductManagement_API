using Product.Management.Common;
using Product.Management.Common.MariaDataAccess;
using Product.Management.Common.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Product.Management.DataAccessLayer.MariaDB.Master
{
    public class CustomerData
    {
        private string ConnectionString = DBContext.Instance.ConnectionString;
        public CustomerBillingDataResponseModel GetCustomerData(CustomerBillingDataGetModel customerBillingDataInput)
        {
            DBCommand dbCommand = null;
            CustomerBillingDataResponseModel customerBillingDataResponse = new CustomerBillingDataResponseModel();
            int outVal = Constants.MINUSTWO;

            try
            {
                DataSet ds = new DataSet();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                dbCommand.AddParameter("p_CustomerName", DbType.String, customerBillingDataInput.SearchText);
                // p_CustomerNamecustomerBillingDataInput.SearchText;
                ds = dbCommand.ExecuteCommand("Master_CustomerData_Get");
                if (ds?.Tables.Count == Constants.ONE && ds.Tables[0].Rows.Count > Constants.ZERO)
                {
                    ICoreData coreData = new CoreData();
                    customerBillingDataResponse.CustomerBillingData = coreData.ConvertToList<CustomerBillingDataModel>(ds.Tables[0]);
                    customerBillingDataResponse.Status = CoreResponseStatus.Success;
                    customerBillingDataResponse.Message = "Data available";
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

            return outVal == Constants.ONE ? customerBillingDataResponse : new Common().GetCoreResponse<CustomerBillingDataResponseModel>(outVal);
        }

        public CustomerBillingDataResponseModel GetCustomerBillingData()
        {
            DBCommand dbCommand = null;
            CustomerBillingDataResponseModel customerBillingDataResponse = new CustomerBillingDataResponseModel();
            int outVal = Constants.MINUSTWO;

            try
            {
                DataSet ds = new DataSet();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                //dbCommand.AddParameter("p_CustomerName", DbType.String, customerBillingDataInput.SearchText);
                // p_CustomerNamecustomerBillingDataInput.SearchText;
                ds = dbCommand.ExecuteCommand("Master_CustomerBillingData_Get");
                if (ds?.Tables.Count == Constants.ONE && ds.Tables[0].Rows.Count > Constants.ZERO)
                {
                    ICoreData coreData = new CoreData();
                    customerBillingDataResponse.CustomerBillingData = coreData.ConvertToList<CustomerBillingDataModel>(ds.Tables[0]);
                    customerBillingDataResponse.Status = CoreResponseStatus.Success;
                    customerBillingDataResponse.Message = "Data available";
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

            return outVal == Constants.ONE ? customerBillingDataResponse : new Common().GetCoreResponse<CustomerBillingDataResponseModel>(outVal);
        }


        public CustomerBillingDataResponseModel InsertCustomerData(CustomerDataModel customerDataInput)
        {
            DBCommand dbCommand = null;
            CustomerBillingDataResponseModel customerDataResponse = new CustomerBillingDataResponseModel();
            int outVal = Constants.MINUSTWO;

            try
            {

                DataSet ds = new DataSet();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                Guid newguid = Guid.NewGuid();
                dbCommand.AddParameter("p_CustomerId", DbType.Binary, newguid);
                dbCommand.AddParameter("p_CustomerName", DbType.String, customerDataInput.CustomerName);
                dbCommand.AddParameter("p_MobileNumber", DbType.String, customerDataInput.MobileNumber);
                dbCommand.AddParameter("p_EmailId", DbType.String, customerDataInput.Email);
                dbCommand.AddParameter("p_PointsEarned", DbType.Decimal, 0.0);
                dbCommand.AddParameter("p_Address1", DbType.String, customerDataInput.Address);
                dbCommand.AddParameter("p_City", DbType.String, customerDataInput.City);
                dbCommand.AddParameter("p_State", DbType.String, customerDataInput.State);
                dbCommand.AddParameter("p_Zipcode", DbType.String, customerDataInput.Zipcode);
                dbCommand.AddParameter("p_CreatedBy", DbType.Binary, customerDataInput.LoggedInUserId);

                ds = dbCommand.ExecuteCommand("Master_Customer_Insert");
                if (ds?.Tables.Count == Constants.ONE && ds.Tables[0].Rows.Count > Constants.ZERO)
                {
                    ICoreData coreData = new CoreData();
                    customerDataResponse.CustomerBillingData = coreData.ConvertToList<CustomerBillingDataModel>(ds.Tables[0]);
                    customerDataResponse.Status = CoreResponseStatus.Success;
                    customerDataResponse.Message = "Data available";
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

            return outVal == Constants.ONE ? customerDataResponse : new Common().GetCoreResponse<CustomerBillingDataResponseModel>(outVal);
        }
    }
}
