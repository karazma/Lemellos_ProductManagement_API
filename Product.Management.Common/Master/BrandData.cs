using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.Common.Master
{
    public class BrandNameDataModel
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
    }

    public class BrandNameResponseModel : CoreResponse
    {
        public BrandNameDataModel[] BrandNameData { get; set; }
    }

    public class BrandNameGetModel : UserToken
    {

    }
}
