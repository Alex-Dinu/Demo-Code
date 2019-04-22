using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUi.Models
{
    public class OrderMvcResponseModel
    {
        public int OrderID { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int CustomerID { get; set; }
    }
}
