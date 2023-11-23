using Product.Management.Common.Master;
using Product.Management.DataAccessLayer.MariaDB.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.BusinessLayer.Master
{
    public class CustomerBL
    {
        CustomerData customerData = null;
        public CustomerBillingDataResponseModel GetCustomerBillingData()
        {
            customerData = new CustomerData();
            return customerData.GetCustomerBillingData();
        }

        public CustomerBillingDataResponseModel GetCustomerData(CustomerBillingDataGetModel customerBillingDataInput)
        {
            customerData = new CustomerData();
            return customerData.GetCustomerData(customerBillingDataInput);
        }

        public CustomerBillingDataResponseModel InsertCustomerData(CustomerDataModel customerDataInput)
        {
            customerData = new CustomerData();
            return customerData.InsertCustomerData(customerDataInput);
        }
    }
}
