using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.Common.Master
{
    public class SaleStatusNameDataModel
    {
        public Guid SaleStatusId { get; set; }
        public string SaleStatusName { get; set; }
    }

    public class SaleStatusNameResponseModel:CoreResponse
    {
        public SaleStatusNameDataModel[] SaleStatusNameData { get; set; }
    }

    public class SaleStatusNameGetModel : UserToken
    {

    }
}
