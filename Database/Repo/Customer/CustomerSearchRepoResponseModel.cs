using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Database.Repo.Customer
{
    public class CustomerSearchRepoResponseModel
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CityName { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public string LogonName { get; set; }

    }
}
