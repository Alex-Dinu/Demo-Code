using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.ExchangeRates
{
    public class ExchangeRateApplicationResponseModel
    {
        public DateTime ExchangeRateDate { get; set; }

        public double USD { get; set; }
        public double GBP { get; set; }
    }
}
