using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebUi.Services.CustomerAddress
{
    public class CustomerAddressMvcRequestModel
    {
        [DataMember(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [DataMember(Name = "City")]
        public string City { get; set; }
        [DataMember(Name = "State")]
        public string State { get; set; }
        [DataMember(Name = "Zip Code")]
        public string Zip { get; set; }
    }
}
