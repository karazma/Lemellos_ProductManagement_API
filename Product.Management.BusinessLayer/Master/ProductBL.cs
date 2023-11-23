using Product.Management.Common;
using Product.Management.Common.Master;
using Product.Management.DataAccessLayer.MariaDB.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.BusinessLayer.Master
{
    public class ProductBL
    {
        private ProductData productData;
        public ProductBL()
        {
            //IsValidToken = TokenManager.ValidateUserToken(userTokenValidate.LoggedInUserName, userTokenValidate.Token);
        }
        public ICoreResponse PostProductData(ProductInsertModel productInput)
        {
            productData = new ProductData();
            return productData.PostProductData(productInput);
        }
        public ICoreResponse UpdateProductData(ProductUpdateModel productInput)
        {
            productData = new ProductData();
            return productData.UpdateProductData(productInput);
        }
        public ICoreResponse DeleteProductData(ProductDeleteModel productInput)
        {
            productData = new ProductData();
            return productData.DeleteProductData(productInput);
        }

        public ICoreResponse PostBulkProductData(ProductBulkUploadModel path)
        {
            productData = new ProductData();
            return productData.PostBulkProductData(path);
        }

        public ProductDataCollectionModel GetProductDataCollection(ProductDataCollectionGetModel productDataInput)
        {
            productData = new ProductData();
            return productData.GetProductDataCollection(productDataInput);
        }
        public ProductSellingDataCollectionModel GetProductSellingDataCollection(ProductSellingDataCollectionGetModel productDataInput)
        {
            productData = new ProductData();
            return productData.GetProductSellingDataCollection(productDataInput);
        }
    }
}
