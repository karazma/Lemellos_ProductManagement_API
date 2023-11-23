using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.Common.Master
{
    public class ProductTypeNameDataModel
    {
        public Guid ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
    }

    public class ProductTypeNameResponseModel:CoreResponse
    {
        public ProductTypeNameDataModel[] ProductTypeNameData { get; set; }
    }

    public class ProductTypeNameGetModel:UserToken
    {

    }
}
