using Product.Management.Common;
using Product.Management.Common.MariaDataAccess;
using Product.Management.Common.Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Product.Management.DataAccessLayer.MariaDB.Transaction
{
    public class SaleOrderDetailData
    {
        private string ConnectionString = DBContext.Instance.ConnectionString;
        public ICoreResponse PostSaleOrderDetailData(SaleOrderDetailInsertDataModel saleOrderDetailData)
        {
            DBCommand dbCommand = null;
            int outVal = Constants.MINUSTWO;

            try
            {
                Guid newGuid = Guid.NewGuid();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;

                dbCommand.AddParameter("p_SaleOrderDetailId", DbType.Binary, newGuid);
                dbCommand.AddParameter("p_SaleOrderId", DbType.Binary, saleOrderDetailData.SaleOrderId);
                if (!string.IsNullOrEmpty(saleOrderDetailData.ProductId))
                    dbCommand.AddParameter("p_ProductId", DbType.Binary, saleOrderDetailData.ProductId);
                else
                    dbCommand.AddParameter("p_ProductId", DbType.Binary, null);
                dbCommand.AddParameter("p_ProductNumber", DbType.String, saleOrderDetailData.ProductNumber);
                dbCommand.AddParameter("p_ProductName", DbType.String, saleOrderDetailData.ProductName);
                dbCommand.AddParameter("p_ProductMRP", DbType.Decimal, saleOrderDetailData.ProductMRP==string.Empty?null: saleOrderDetailData.ProductMRP);
                dbCommand.AddParameter("p_ProductPrice", DbType.Decimal, saleOrderDetailData.ProductPrice);
                dbCommand.AddParameter("p_ProductBillAmount", DbType.Decimal, saleOrderDetailData.ProductBillAmount);
                dbCommand.AddParameter("p_ProductQuantity", DbType.Int32, saleOrderDetailData.ProductQuantity);
                dbCommand.AddParameter("p_ProductDiscountPercentage", DbType.Double, saleOrderDetailData.ProductDiscountPercentage);
                dbCommand.AddParameter("p_ProductDiscountAmount", DbType.Decimal, saleOrderDetailData.ProductDiscountAmount);
                dbCommand.AddParameter("p_CreatedBy", DbType.Binary, saleOrderDetailData.LoggedInUserId);
                outVal = dbCommand.ExecuteNonQuery("Log_SaleOrderDetail_Insert");
            }
            catch (Exception ex)
            {
                //Log.Error(Constants.SourceName, "CustomerAccountData->PostCustomerAccount", ex);
            }
            finally
            {
                if (dbCommand != null)
                    dbCommand.Dispose();
            }

            Common common = new Common();
            return common.GetCoreResponsePost("Sale order detail", outVal);
        }

        public ICoreResponse UpdateSaleOrderDetailData(SaleOrderDetailUpdateDataModel saleOrderDetailData)
        {
            DBCommand dbCommand = null;
            int outVal = Constants.MINUSTWO;

            try
            {
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                dbCommand.AddParameter("p_SaleOrderDetailId", DbType.Binary, saleOrderDetailData.SaleOrderDetailId);
                dbCommand.AddParameter("p_SaleOrderId", DbType.Binary, saleOrderDetailData.SaleOrderId);
                if (!string.IsNullOrEmpty(saleOrderDetailData.ProductId))
                    dbCommand.AddParameter("p_ProductId", DbType.Binary, saleOrderDetailData.ProductId);
                else
                    dbCommand.AddParameter("p_ProductId", DbType.Binary, null);
                dbCommand.AddParameter("p_ProductNumber", DbType.String, saleOrderDetailData.ProductNumber);
                dbCommand.AddParameter("p_ProductName", DbType.String, saleOrderDetailData.ProductName);
                dbCommand.AddParameter("p_ProductMRP", DbType.Decimal, saleOrderDetailData.ProductMRP == string.Empty ? null : saleOrderDetailData.ProductMRP);
                dbCommand.AddParameter("p_ProductPrice", DbType.Decimal, saleOrderDetailData.ProductPrice);
                dbCommand.AddParameter("p_ProductBillAmount", DbType.Decimal, saleOrderDetailData.ProductBillAmount);
                dbCommand.AddParameter("p_ProductQuantity", DbType.Int32, saleOrderDetailData.ProductQuantity);
                dbCommand.AddParameter("p_ProductDiscountPercentage", DbType.Double, saleOrderDetailData.ProductDiscountPercentage);
                dbCommand.AddParameter("p_ProductDiscountAmount", DbType.Decimal, saleOrderDetailData.ProductDiscountAmount);
                dbCommand.AddParameter("p_UpdatedBy", DbType.Binary, saleOrderDetailData.LoggedInUserId);
                outVal = dbCommand.ExecuteNonQuery("Log_SaleOrderDetail_Update");
            }
            catch (Exception ex)
            {
                //Log.Error(Constants.SourceName, "CustomerAccountData->PostCustomerAccount", ex);
            }
            finally
            {
                if (dbCommand != null)
                    dbCommand.Dispose();
            }

            Common common = new Common();
            return common.GetCoreResponseUpdate("Sale order detail", outVal);
        }

        public SalePendingOrderDetailSingleDataModel GetSalePendingOrderDetailData(SalePendingOrderDetailGetModel saleOrderInputData)
        {
            DBCommand dbCommand = null;
            SalePendingOrderDetailSingleDataModel salePendingOrderDetailData = new SalePendingOrderDetailSingleDataModel();
            int outVal = Constants.MINUSTWO;

            try
            {
                DataSet ds = new DataSet();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                dbCommand.AddParameter("p_SaleOrderId", DbType.Binary, saleOrderInputData.SaleOrderId);
                ds = dbCommand.ExecuteCommand("Log_SalePendingOrderDetail_Get");
                if (ds?.Tables.Count == Constants.ONE && ds.Tables[0].Rows.Count > Constants.ZERO)
                {
                    ICoreData coreData = new CoreData();
                    salePendingOrderDetailData.SalePendingOrderDetailData = coreData.ConvertToList<SalePendingOrderDetailDataModel>(ds.Tables[0]);
                    salePendingOrderDetailData.Status = CoreResponseStatus.Success;
                    salePendingOrderDetailData.Message = "Data available";
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

            return outVal == Constants.ONE ? salePendingOrderDetailData : new Common().GetCoreResponse<SalePendingOrderDetailSingleDataModel>(outVal);
        }
    }
}
