using Product.Management.Common.Master;
using Product.Management.DataAccessLayer.MariaDB.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.BusinessLayer.Master
{
    public class VendorBL
    {
        VendorData vendorData = null;
        public VendorNameResponseModel GetVendorNameData()
        {
            vendorData = new VendorData();
            return vendorData.GetVendorNameData();
        }
    }
}
