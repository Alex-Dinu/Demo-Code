using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebUi.Services.Orders
{
    [DataContract(Name = "clientOrders")]

    public class ClientOrderServiceResponseModel
    {
        [DataMember(Name = "clientId")]
        public int PersonID { get; set; }
        [DataMember(Name = "name")]
        public string FullName { get; set; }
        [DataMember(Name = "emailAddress")]
        public string EmailAddress { get; set; }
        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }
        [DataMember(Name = "orderId")]
        public int OrderID { get; set; }
        [DataMember(Name = "orderDescription")]
        public string Description { get; set; }
        [DataMember(Name = "orderPrice")]
        public decimal UnitPrice { get; set; }
    }
}
