using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Database.Repo.Orders
{
    public class OrderRepoResponse
    {
        [Key]
        public int OrderID { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int CustomerID { get; set; }



    }
}
