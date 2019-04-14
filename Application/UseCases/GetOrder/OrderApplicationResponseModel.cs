using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.GetOrder
{
    public class OrderApplicationResponseModel
    {
        public int OrderID { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int CustomerID { get; set; }
    }
}
