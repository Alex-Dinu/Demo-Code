﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.UseCases.GetClientOrders
{
    public class ClientOrderApplicationResponseModel
    {
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        [Key]
        public int OrderID { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
