using Product.Management.Common.Master;
using Product.Management.DataAccessLayer.MariaDB.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.BusinessLayer.Master
{
    public class BrandBL
    {
        BrandData brandData = null;
        public BrandNameResponseModel GetBrandNameData()
        {
            brandData = new BrandData();
            return brandData.GetBrandNameData();
        }
    }
}
