using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebUi.Models
{

    public class OrderMvcResponseListModel
    {
        [DisplayName("Person ID")]
        public int PersonID { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [DisplayName("EMail Address")]
        [DataType(DataType.EmailAddress)]

        public string EmailAddress { get; set; }
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DisplayName("Order ID")]
        public int OrderID { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Unit Price")]
        [DataType(DataType.Currency)]

        public decimal UnitPrice { get; set; }

    }
}
