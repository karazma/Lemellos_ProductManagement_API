using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.Common.Master
{
    public class PaymentTypeNameDataModel
    {
        public Guid PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
    }

    public class PaymentTypeNameResponseModel:CoreResponse
    {
        public PaymentTypeNameDataModel[] PaymentTypeNameData { get; set; }
    }

    public class PaymentTypeNameDataGetModel : UserToken
    {

    }
}
