using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.Common.Master
{
    public class PaymentStatusNameDataModel
    {
        public Guid PaymentStatusId { get; set; }
        public string PaymentStatusName { get; set; }
    }

    public class PaymentStatusNameResponseModel:CoreResponse
    {
        public PaymentStatusNameDataModel[] PaymentStatusNameData { get; set; }
    }

    public class PaymentStatusNameDataGetModel : UserToken
    {
        
    }
}
