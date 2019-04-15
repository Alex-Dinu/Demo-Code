using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.SearchCustomerByName
{
    public class CustomerSearchApplicationResponseModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CityName { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public string LogonName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime HireDate { get; set; }

    }
}
