using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUi.Models
{
    public class ExchangeRateMvcResponseModel
    {
        public DateTime ExchangeRateDate { get; set; }

        public double USD { get; set; }
        public double GBP { get; set; }

    }
}
