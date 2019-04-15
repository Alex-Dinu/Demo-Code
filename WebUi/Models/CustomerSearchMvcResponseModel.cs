using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUi.CustomValidatorAttributes;

namespace WebUi.Models
{
    public class CustomerSearchMvcResponseModel
    {
        [DisplayName("Customer ID")]
        public int CustomerID { get; set; }
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [DisplayName("City")]
        public string CityName { get; set; }
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [Remote("CheckIfLogonAlreadyExists", "CustomerSearch", ErrorMessage = "Phone Number already exists")]
        public string PhoneNumber { get; set; }
        [DisplayName("Fax Number")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Invalid Fax number.")]
        public string FaxNumber { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [DisplayName("Preferred Name")]
        public string PreferredName { get; set; }
        [DisplayName("Logon Name")]
        [ValidLogon("PreferredName", ErrorMessage = "Invalid Logon")]
        public string LogonName { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        [DisplayName("Hire Date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }


    }
}
