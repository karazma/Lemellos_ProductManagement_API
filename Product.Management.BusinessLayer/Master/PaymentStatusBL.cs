using Product.Management.Common.Master;
using Product.Management.DataAccessLayer.MariaDB.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.BusinessLayer.Master
{
    public class PaymentStatusBL
    {
        PaymentStatusData paymentStatusData = null;
        public PaymentStatusNameResponseModel GetPaymentStatusNameData(PaymentStatusNameDataGetModel paymentStatusNameDataInput)
        {
            paymentStatusData = new PaymentStatusData();
            return paymentStatusData.GetPaymentStatusNameData();
        }
    }
}
