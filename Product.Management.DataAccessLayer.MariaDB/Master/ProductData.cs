using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Product.Management.Common;
using Product.Management.Common.MariaDataAccess;
using Product.Management.Common.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Product.Management.DataAccessLayer.MariaDB.Master
{
    public class ProductData
    {
        private string ConnectionString = DBContext.Instance.ConnectionString;
        public ICoreResponse PostProductData(ProductInsertModel productData)
        {
            DBCommand dbCommand = null;
            int outVal = Constants.MINUSTWO;

            try
            {
                Guid newGuid = Guid.NewGuid();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                dbCommand.AddParameter("p_ProductId", DbType.Binary , newGuid);
                dbCommand.AddParameter("p_BarcodeId", DbType.String, productData.BarcodeId);
                dbCommand.AddParameter("p_ProductName", DbType.String, productData.ProductName);
                dbCommand.AddParameter("p_ProductDescription", DbType.String, productData.ProductDescription);
                dbCommand.AddParameter("p_ProductTypeId", DbType.Binary, productData.ProductTypeId);
                if (productData.MRP > 0)
                    dbCommand.AddParameter("p_MRP", DbType.Decimal, productData.MRP);
                else
                    dbCommand.AddParameter("p_MRP", DbType.Decimal, null);
                if (productData.BuyingPrice > 0)
                    dbCommand.AddParameter("p_BuyingPrice", DbType.Decimal, productData.BuyingPrice);
                else
                    dbCommand.AddParameter("p_BuyingPrice", DbType.Decimal, null);
                dbCommand.AddParameter("p_SellingPrice", DbType.Decimal, productData.SellingPrice);                              
                dbCommand.AddParameter("p_BrandId", DbType.Binary, productData.BrandId);
                dbCommand.AddParameter("p_VendorId", DbType.Binary, productData.VendorId);
                dbCommand.AddParameter("p_TotalCount", DbType.Int32, productData.TotalCount);
                dbCommand.AddParameter("p_ProductImagePath", DbType.String, productData.ProductImagePath);
                dbCommand.AddParameter("p_CreatedBy", DbType.Binary, productData.LoggedInUserId);
                dbCommand.AddParameter("p_IsActive", DbType.Boolean, productData.IsActive);
                dbCommand.AddParameter("p_gst", DbType.Int32, productData.gst);
                outVal = dbCommand.ExecuteNonQuery("Master_Product_Insert");
                
                
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
            return common.GetCoreResponsePost("Product", outVal);
        }

        public ICoreResponse UpdateProductData(ProductUpdateModel productData)
        {
            DBCommand dbCommand = null;
            int outVal = Constants.MINUSTWO;

            try
            {
                Guid newGuid = Guid.NewGuid();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                dbCommand.AddParameter("p_ProductId", DbType.Binary, productData.ProductId);
                dbCommand.AddParameter("p_ProductName", DbType.String, productData.ProductName);
                dbCommand.AddParameter("p_ProductDescription", DbType.String, productData.ProductDescription);
                dbCommand.AddParameter("p_ProductTypeId", DbType.Binary, productData.ProductTypeId);
                dbCommand.AddParameter("p_MRP", DbType.Decimal, productData.MRP);
                dbCommand.AddParameter("p_BuyingPrice", DbType.Decimal, productData.BuyingPrice);
                dbCommand.AddParameter("p_BasePrice", DbType.Decimal, productData.SellingPrice);
                dbCommand.AddParameter("p_BarcodeId", DbType.String, productData.BarcodeId);
                dbCommand.AddParameter("p_BrandId", DbType.Binary, productData.BrandId);
                dbCommand.AddParameter("p_VendorId", DbType.Binary, productData.VendorId);
                dbCommand.AddParameter("p_TotalCount", DbType.Int32, productData.TotalCount);
                dbCommand.AddParameter("p_ProductImagePath", DbType.String, productData.ProductImagePath);
                dbCommand.AddParameter("p_UpdatedBy", DbType.Binary, productData.LoggedInUserId);
                dbCommand.AddParameter("p_IsActive", DbType.Boolean, productData.IsActive);
                outVal = dbCommand.ExecuteNonQuery("Master_Product_Update");
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
            return common.GetCoreResponseUpdate("Product", outVal);
        }

        public ICoreResponse DeleteProductData(ProductDeleteModel productData)
        {
            DBCommand dbCommand = null;
            int outVal = Constants.MINUSTWO;

            try
            {
                Guid newGuid = Guid.NewGuid();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                dbCommand.AddParameter("p_ProductId", DbType.Binary, productData.ProductId);
                dbCommand.AddParameter("p_UpdatedBy", DbType.Binary, productData.LoggedInUserId);
                outVal = dbCommand.ExecuteNonQuery("Master_Product_Delete");
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
            return common.GetCoreResponseUpdate("Product", outVal);
        }

        public ProductDataCollectionModel GetProductDataCollection(ProductDataCollectionGetModel productDataInput)
        {
            DBCommand dbCommand = null;
            ProductDataCollectionModel productData = new ProductDataCollectionModel();
            int outVal = Constants.MINUSTWO;

            try
            {
                DataSet ds = new DataSet();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                dbCommand.AddParameter("p_PageNumber", DbType.Int32, productDataInput.PageNumber);
                dbCommand.AddParameter("p_PageSize", DbType.Int32, productDataInput.PageSize);
                dbCommand.AddParameter("p_SearchText", DbType.String, productDataInput.SearchText == null ? string.Empty : productDataInput.SearchText);
                ds = dbCommand.ExecuteCommand("Master_ProductCollection_Get");
                if (ds?.Tables.Count == Constants.ONE && ds.Tables[0].Rows.Count > Constants.ZERO)
                {
                    ICoreData coreData = new CoreData();
                    productData.ProductData = coreData.ConvertToList<ProductDataModel>(ds.Tables[0]);
                    //var totalRecordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                    //if (ds.Tables[1]?.Rows.Count > Constants.ZERO)
                    //{
                        //var pagingData = coreData.ConvertToList<ProductDataPagingModel>(ds.Tables[1]);
                        //productData.ProductDataPaging = pagingData?.Length > 0 ? pagingData[0] : null;
                        productData.Status = CoreResponseStatus.Success;
                        productData.Message = "Data available";
                        outVal = Constants.ONE;
                    //}
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

            return outVal == Constants.ONE ? productData : new Common().GetCoreResponse<ProductDataCollectionModel>(outVal);
        }

        public ProductSellingDataCollectionModel GetProductSellingDataCollection(ProductSellingDataCollectionGetModel productDataInput)
        {
            DBCommand dbCommand = null;
            ProductSellingDataCollectionModel productSellingData = new ProductSellingDataCollectionModel();
            int outVal = Constants.MINUSTWO;

            try
            {
                DataSet ds = new DataSet();
                dbCommand = new DBCommand(ConnectionString);
                dbCommand.Type = CommandType.StoredProcedure;
                dbCommand.AddParameter("p_SearchText", DbType.String, productDataInput.SearchText == null ? string.Empty : productDataInput.SearchText);
                ds = dbCommand.ExecuteCommand("Master_ProductSelling_GetByKeyword");
                if (ds?.Tables.Count == Constants.ONE && ds.Tables[0].Rows.Count > Constants.ZERO)
                {
                    ICoreData coreData = new CoreData();
                    productSellingData.ProductSellingData = coreData.ConvertToList<ProductSellingDataModel>(ds.Tables[0]);
                    productSellingData.Status = CoreResponseStatus.Success;
                    productSellingData.Message = "Data available";
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

            return outVal == Constants.ONE ? productSellingData : new Common().GetCoreResponse<ProductSellingDataCollectionModel>(outVal);
        }

        internal DataSet ParseExceldata(string filePath)
        {
            DataSet dataSet = new DataSet();
            DataTable tableduplicate = new DataTable();
            tableduplicate.TableName = "Duplicate";
            try
            {
                IWorkbook xlWorkBook = null;
                ISheet xlWorkSheet = null;
                string ext = Path.GetExtension(filePath);
                if (ext.ToLower() == ".xlsx")
                {
                    using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        xlWorkBook = new XSSFWorkbook(file);
                    }
                }
                else if (ext.ToLower() == ".xls")
                {
                    using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        xlWorkBook = new HSSFWorkbook(file);
                    }
                }

                for (int sheetCnt = 0; sheetCnt < xlWorkBook.NumberOfSheets; sheetCnt++)
                {
                    int[] cHeader = new int[50];
                    int cl = 0;
                    int cH = 0;
                    int rs = 0;

                    xlWorkSheet = xlWorkBook.GetSheetAt(sheetCnt);

                    if (xlWorkSheet.LastRowNum <= 0) //To skip if worksheet empty
                        continue;                   
                  
                        DataTable table = new DataTable();
                        DataRow row = table.NewRow();
                        table.TableName = xlWorkSheet.SheetName.ToUpper();

                        IRow headerRow = null;

                        for (int i = 0; i <= xlWorkSheet.LastRowNum; i++) //Get headers
                        {
                            if (xlWorkSheet.GetRow(i) != null)
                            {
                                headerRow = xlWorkSheet.GetRow(i);
                                var lstcolumn = headerRow.Cells.ToList();
                                var count = lstcolumn.Count;

                                for (int ind = count - 1; ind > -1; ind--)
                                {
                                     if (lstcolumn[ind].StringCellValue == string.Empty) lstcolumn.RemoveAt(ind);
                                }

                                lstcolumn = lstcolumn.Distinct().ToList();

                                var totalDupeItems = lstcolumn.GroupBy(x => x.StringCellValue.ToString()).Count(grp => grp.Count() > 1);

                                if(totalDupeItems > 0)
                                {
                                  dataSet.Tables.Add(tableduplicate);
                                }

                                cl = xlWorkSheet.GetRow(i).LastCellNum;
                                for (int rw = headerRow.FirstCellNum; rw < cl; rw++)
                                {
                                    if (headerRow.GetCell(rw) != null)
                                    {                                                                          
                                            table.Columns.Add(headerRow.GetCell(rw).StringCellValue.ToString().TrimStart().TrimEnd());                                            
                                            cHeader[cH] = rw;
                                            cH++;                                       
                                    }
                                }
                                rs = i + 1;
                                break;
                            }
                        }

                        for (int i = rs; i <= xlWorkSheet.LastRowNum; i++)
                        {
                            IRow xlRow = null;

                            if (xlWorkSheet.GetRow(i) != null) //To skip if row empty
                                xlRow = xlWorkSheet.GetRow(i);
                            else
                                continue;

                            row = table.NewRow();
                            for (int j = 0; j < cH; j++)
                            {
                                if (xlRow.GetCell(cHeader[j]) != null)
                                {
                                    row[j] = xlRow.GetCell(cHeader[j]).ToString().TrimStart().TrimEnd();
                                }
                            }
                            table.Rows.Add(row);
                        }
                        dataSet.Tables.Add(table);
                    
                }

                xlWorkBook.Close();
            }
            catch (Exception ex)
            {
               // Log.webErrorMessage("SelfConfiguration-->ParseExceldata" + ex.Message + " - " + ex.StackTrace);
            }
            return dataSet;
        }

        public ICoreResponse PostBulkProductData(ProductBulkUploadModel productData)
        {
            DBCommand dbCommand = null;
            int outVal = Constants.MINUSTWO;
            var FilePath = productData.FilePath;
            try
            {
              if(File.Exists(FilePath))
              {
                    DataSet ds = ParseExceldata(FilePath);
                    DataTable fieldTable = ds.Tables[0];

                    foreach (DataRow dr in fieldTable.Rows)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ProductName"]))
                            && !string.IsNullOrEmpty(Convert.ToString(dr["SellingPrice"]))
                            && !string.IsNullOrEmpty(Convert.ToString(dr["BarcodeId"]))
                            && !string.IsNullOrEmpty(Convert.ToString(dr["TotalCount"]))
                            )
                        {
                            Guid newGuid = Guid.NewGuid();
                            dbCommand = new DBCommand(ConnectionString);
                            dbCommand.Type = CommandType.StoredProcedure;
                            dbCommand.AddParameter("p_ProductId", DbType.Binary, newGuid);
                            dbCommand.AddParameter("p_ProductName", DbType.String, dr["ProductName"]);
                            dbCommand.AddParameter("p_ProductDescription", DbType.String, dr["ProductDescription"]);
                            dbCommand.AddParameter("p_ProductType", DbType.String, string.IsNullOrEmpty(Convert.ToString(dr["ProductType"])) ? "Others" : dr["ProductType"]);
                            dbCommand.AddParameter("p_MRP", DbType.Decimal, string.IsNullOrEmpty(Convert.ToString(dr["MRP"])) ? null : dr["MRP"]);
                            dbCommand.AddParameter("p_BuyingPrice", DbType.Decimal, string.IsNullOrEmpty(Convert.ToString(dr["BuyingPrice"]))?null: dr["BuyingPrice"]);
                            dbCommand.AddParameter("p_SellingPrice", DbType.Decimal, dr["SellingPrice"]);
                            dbCommand.AddParameter("p_BarcodeId", DbType.String, dr["BarcodeId"]);
                            dbCommand.AddParameter("p_Brand", DbType.String, string.IsNullOrEmpty(Convert.ToString(dr["Brand"]))?"Others": dr["Brand"]);
                            dbCommand.AddParameter("p_Vendor", DbType.String, string.IsNullOrEmpty(Convert.ToString(dr["Vendor"])) ? "Others" : dr["Vendor"]);
                            dbCommand.AddParameter("p_TotalCount", DbType.Int32, dr["TotalCount"]);
                            dbCommand.AddParameter("p_ProductImagePath", DbType.String, dr["ProductImagePath"]);
                            outVal = dbCommand.ExecuteNonQuery("Master_Product_BulkInsert");
                        }
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
            return common.GetCoreResponsePost("Product", outVal);
        }
    }
}
