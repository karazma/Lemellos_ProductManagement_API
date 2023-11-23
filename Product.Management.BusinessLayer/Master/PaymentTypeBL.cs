using Product.Management.Common.Master;
using Product.Management.DataAccessLayer.MariaDB.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.BusinessLayer.Master
{
    public class PaymentTypeBL
    {
        PaymentTypeData paymentTypeData = null;
        public PaymentTypeNameResponseModel GetPaymentStatusNameData(PaymentTypeNameDataGetModel paymentTypeNameDataInput)
        {
            paymentTypeData = new PaymentTypeData();
            return paymentTypeData.GetPaymentTypeNameData();
        }
    }
}
