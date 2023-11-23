using Product.Management.Common.Master;
using Product.Management.DataAccessLayer.MariaDB.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.BusinessLayer.Master
{
    public class ProductTypeBL
    {
        ProductTypeData productTypeData = null;
        public ProductTypeNameResponseModel GetProductTypeNameData()
        {
            productTypeData = new ProductTypeData();
            return productTypeData.GetProductTypeNameData();
        }
    }
}
