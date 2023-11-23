using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Management.Common.Master
{
    public class CustomerBillingDataModel
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
    }

    public class CustomerDataModel : UserToken
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public decimal Points { get; set; }
        public Guid Membership { get; set; }
        public Guid ReferredBy { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

    }

    public class CustomerBillingDataResponseModel : CoreResponse
    {
        public CustomerBillingDataModel[] CustomerBillingData { get; set; }
    }

    public class CustomerDataResponseModel : CoreResponse
    {
        public CustomerDataModel[] CustomerData { get; set; }
    }

    public class CustomerBillingDataGetModel : UserToken
    {
        public string SearchText { get; set; }
    }
    public class CustomerDataGetModel : UserToken
    {

    }
}
