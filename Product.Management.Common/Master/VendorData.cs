using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.Common.Master
{
    public class VendorNameDataModel
    {
        public Guid VendorId { get; set; }
        public string VendorName { get; set; }
    }

    public class VendorNameResponseModel:CoreResponse
    {
        public VendorNameDataModel[] VendorNameData { get; set; }
    }

    public class VendorNameGetModel:UserToken
    {

    }
}
