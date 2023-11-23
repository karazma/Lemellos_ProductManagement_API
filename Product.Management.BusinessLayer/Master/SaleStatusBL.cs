using Product.Management.Common.Master;
using Product.Management.DataAccessLayer.MariaDB.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.BusinessLayer.Master
{
    public class SaleStatusBL
    {
        SaleStatusData saleStatus = null;
        public SaleStatusNameResponseModel GetSaleStatusNameData(SaleStatusNameGetModel SaleStatusNameInput)
        {
            saleStatus = new SaleStatusData();
            return saleStatus.GetSaleStatusNameData();
        }
    }
}
