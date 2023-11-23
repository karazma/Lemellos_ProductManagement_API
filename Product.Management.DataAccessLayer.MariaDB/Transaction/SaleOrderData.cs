using Product.Management.Common;
using Product.Management.Common.MariaDataAccess;
using Product.Management.Common.Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Product.Management.DataAccessLayer.MariaDB.Transaction
{
    public class SaleOrderData
    {
        private string ConnectionString = DBContext.Instance.ConnectionString;
        public ICoreResponse PostSaleOrderData(SaleOrderInsertModel saleData)
        {
            DBCommand dbCommand = null;
            int outVal = Constants.MINUSTWO;
            Guid newGuid = Guid.NewGuid();

            try
            {
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                dbCommand.AddParameter("p_SaleOrderId", DbType.String, newGuid);
                dbCommand.AddParameter("p_SaleOrderNumber", DbType.String, saleData.SaleOrderNumber);
                dbCommand.AddParameter("p_SaleBillAmount", DbType.Decimal, saleData.SaleBillAmount);
                dbCommand.AddParameter("p_SaleStatusId", DbType.Binary, saleData.SaleStatusId);
                if (!string.IsNullOrEmpty(saleData.CustomerId))
                    dbCommand.AddParameter("p_CustomerId", DbType.Binary, saleData.CustomerId);
                else
                    dbCommand.AddParameter("p_CustomerId", DbType.Binary, null);
                dbCommand.AddParameter("p_GuestName", DbType.String, saleData.GuestName);
                dbCommand.AddParameter("p_PaymentTypeId", DbType.Binary, saleData.PaymentTypeId);
                dbCommand.AddParameter("p_PaymentStatusId", DbType.Binary, saleData.PaymentStatusId);
                dbCommand.AddParameter("p_CreatedBy", DbType.Binary, saleData.LoggedInUserId);
                outVal = dbCommand.ExecuteNonQuery("Log_SaleOrder_Insert");

                foreach (var item in saleData.SaleOrderDetailInsertData)
                {
                    SaleOrderDetailInsertDataModel saleOrderDetailInsertData = new SaleOrderDetailInsertDataModel
                    {
                         SaleOrderId = newGuid,
                         ProductId =  item.ProductId,
                         ProductNumber = item.ProductNumber,
                         ProductName = item.ProductName,
                         ProductBillAmount = item.ProductBillAmount,
                         ProductPrice = item.ProductPrice,
                         ProductMRP=item.ProductMRP,
                         ProductQuantity = item.ProductQuantity,
                         ProductDiscountAmount = item.ProductDiscountAmount,
                         ProductDiscountPercentage = item.ProductDiscountPercentage,
                         LoggedInUserId = saleData.LoggedInUserId
                    };
                    SaleOrderDetailData saleOrderDetailData = new SaleOrderDetailData();
                    saleOrderDetailData.PostSaleOrderDetailData(saleOrderDetailInsertData);
                }
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
            return common.GetCoreResponsePost("Sale order", outVal, newGuid.ToString());
        }

        public ICoreResponse UpdateSaleOrderData(SaleOrderUpdateModel saleData)
        {
            DBCommand dbCommand = null;
            int outVal = Constants.MINUSTWO;

            try
            {
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                dbCommand.AddParameter("p_SaleOrderId", DbType.Binary, saleData.SaleOrderId);
                dbCommand.AddParameter("p_SaleBillAmount", DbType.Decimal, saleData.SaleBillAmount);
                dbCommand.AddParameter("p_SaleStatusId", DbType.Binary, saleData.SaleStatusId);
                dbCommand.AddParameter("p_CustomerId", DbType.Binary, saleData.CustomerId);
                dbCommand.AddParameter("p_GuestName", DbType.String, saleData.GuestName);
                dbCommand.AddParameter("p_PaymentTypeId", DbType.Binary, saleData.PaymentTypeId);
                dbCommand.AddParameter("p_PaymentStatusId", DbType.Binary, saleData.PaymentStatusId);
                dbCommand.AddParameter("p_UpdatedBy", DbType.Binary, saleData.LoggedInUserId);
                outVal = dbCommand.ExecuteNonQuery("Log_SaleOrder_Update");

                foreach (var item in saleData.SaleOrderDetailUpdateData)
                {
                    SaleOrderDetailData saleOrderDetailData = new SaleOrderDetailData();

                    if (!string.IsNullOrEmpty(item.SaleOrderDetailId))
                    {
                        SaleOrderDetailUpdateDataModel saleOrderDetailUpdateData = new SaleOrderDetailUpdateDataModel
                        {                            
                            SaleOrderId = saleData.SaleOrderId,
                            ProductBillAmount = item.ProductBillAmount,
                            ProductDiscountAmount = item.ProductDiscountAmount,
                            ProductDiscountPercentage = item.ProductDiscountPercentage,
                            ProductId = item.ProductId,
                            ProductMRP = item.ProductMRP,
                            ProductName = item.ProductName,
                            ProductNumber = item.ProductNumber,
                            ProductPrice = item.ProductPrice,
                            ProductQuantity = item.ProductQuantity,
                            SaleOrderDetailId = item.SaleOrderDetailId,
                            LoggedInUserId = saleData.LoggedInUserId
                        };
                        saleOrderDetailData.UpdateSaleOrderDetailData(saleOrderDetailUpdateData);
                    }
                    else
                    {
                        SaleOrderDetailInsertDataModel saleOrderDetailInsertData = new SaleOrderDetailInsertDataModel
                        {
                            SaleOrderId = saleData.SaleOrderId,
                            ProductBillAmount = item.ProductBillAmount,
                            ProductDiscountAmount = item.ProductDiscountAmount,
                            ProductDiscountPercentage = item.ProductDiscountPercentage,
                            ProductId = item.ProductId,
                            ProductMRP = item.ProductMRP,
                            ProductName = item.ProductName,
                            ProductNumber = item.ProductNumber,
                            ProductPrice = item.ProductPrice,
                            ProductQuantity = item.ProductQuantity,
                            LoggedInUserId = saleData.LoggedInUserId
                        };
                        saleOrderDetailData.PostSaleOrderDetailData(saleOrderDetailInsertData);
                    }
                }
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
            return common.GetCoreResponseUpdate("Sale Order", outVal);
        }

        public ICoreResponse UpdateSaleOrderPrintStatus(SaleOrderPrintStatusModel saleData)
        {
            DBCommand dbCommand = null;
            int outVal = Constants.MINUSTWO;

            try
            {
                Guid newGuid = Guid.NewGuid();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                dbCommand.AddParameter("p_SaleOrderId", DbType.Binary, new Guid(saleData.SaleOrderId));
                dbCommand.AddParameter("p_IsPrinted", DbType.Decimal, saleData.IsPrinted);

                outVal = dbCommand.ExecuteNonQuery("Log_SaleOrderPrintStatus_Update");
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
            return common.GetCoreResponseUpdate("Sale order print status", outVal);
        }

        public ICoreResponse DeleteSaleOrderData(SaleOrderDeleteModel saleData)
        {
            DBCommand dbCommand = null;
            int outVal = Constants.MINUSTWO;

            try
            {
                Guid newGuid = Guid.NewGuid();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                dbCommand.AddParameter("s_SaleOrderId", DbType.Binary, saleData.SaleOrderId);
                dbCommand.AddParameter("s_UpdatedBy", DbType.Binary, saleData.LoggedInUserId);
                outVal = dbCommand.ExecuteNonQuery("Log_SaleOrder_Delete");
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
            return common.GetCoreResponseUpdate("Sale", outVal);
        }

        public SalePendingOrderCollectionDataModel GetSalePendingOrderData(SalePendingOrderGetModel saleOrderInputData)
        {
            DBCommand dbCommand = null;
            SalePendingOrderCollectionDataModel salePendingOrderData = new SalePendingOrderCollectionDataModel();
            int outVal = Constants.MINUSTWO;

            try
            {
                DataSet ds = new DataSet();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                ds = dbCommand.ExecuteCommand("Log_SalePendingOrder_Get");
                if (ds?.Tables.Count == Constants.ONE && ds.Tables[0].Rows.Count > Constants.ZERO)
                {
                    ICoreData coreData = new CoreData();
                    salePendingOrderData.SalePendingOrderData = coreData.ConvertToList<SalePendingOrderDataModel>(ds.Tables[0]);
                    salePendingOrderData.Status = CoreResponseStatus.Success;
                    salePendingOrderData.Message = "Data available";
                    outVal = Constants.ONE;

                    foreach (var item in salePendingOrderData.SalePendingOrderData)
                    {
                        SalePendingOrderDetailGetModel salePendingOrderDetailGetModel = new SalePendingOrderDetailGetModel
                        {
                            SaleOrderId = item.SaleOrderId
                        };
                        SaleOrderDetailData saleOrderDetailData = new SaleOrderDetailData();
                        item.SalePendingOrderDetailData = saleOrderDetailData.GetSalePendingOrderDetailData(salePendingOrderDetailGetModel)?.SalePendingOrderDetailData;
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

            return outVal == Constants.ONE ? salePendingOrderData : new Common().GetCoreResponse<SalePendingOrderCollectionDataModel>(outVal);
        }

        public SalePendingOrderCollectionDataModel GetSaleOrderData(SaleOrderGetModel saleOrderInputData)
        {
            DBCommand dbCommand = null;
            SalePendingOrderCollectionDataModel salePendingOrderData = new SalePendingOrderCollectionDataModel();
            int outVal = Constants.MINUSTWO;

            try
            {
                DataSet ds = new DataSet();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                dbCommand.AddParameter("p_fromDate", DbType.Binary, saleOrderInputData.FromOrderDate);
                dbCommand.AddParameter("p_toDate", DbType.Binary, saleOrderInputData.ToOrderDate);
                ds = dbCommand.ExecuteCommand("Log_SaleOrder_Get");
                if (ds?.Tables.Count == Constants.ONE && ds.Tables[0].Rows.Count > Constants.ZERO)
                {
                    ICoreData coreData = new CoreData();
                    salePendingOrderData.SalePendingOrderData = coreData.ConvertToList<SalePendingOrderDataModel>(ds.Tables[0]);
                    salePendingOrderData.Status = CoreResponseStatus.Success;
                    salePendingOrderData.Message = "Data available";
                    outVal = Constants.ONE;

                    foreach (var item in salePendingOrderData.SalePendingOrderData)
                    {
                        SalePendingOrderDetailGetModel salePendingOrderDetailGetModel = new SalePendingOrderDetailGetModel
                        {
                            SaleOrderId = item.SaleOrderId
                        };
                        SaleOrderDetailData saleOrderDetailData = new SaleOrderDetailData();
                        item.SalePendingOrderDetailData = saleOrderDetailData.GetSalePendingOrderDetailData(salePendingOrderDetailGetModel)?.SalePendingOrderDetailData;
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

            return outVal == Constants.ONE ? salePendingOrderData : new Common().GetCoreResponse<SalePendingOrderCollectionDataModel>(outVal);
        }
    }
}
