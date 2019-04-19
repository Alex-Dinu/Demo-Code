using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.GetSomeData
{
    public interface ISomeDataGetter
    {
        Task<int> GetTemperature();
        Task<decimal> GetStockPrice();
        Task<string> GetStateName();
        Task<DateTime> GetARandomDate();
    }

    public class SomeDataGetter : ISomeDataGetter
    {
        Random rnd = new Random();

        public async Task<int> GetTemperature()
        {
            //await Task.Delay(rnd.Next(1000, 4000));
            return rnd.Next(-20, 113);
        }

        public async Task<decimal> GetStockPrice()
        {
            //await Task.Delay(rnd.Next(1000, 4000));
            return rnd.Next(165, 225);
        }

        public async Task<string> GetStateName()
        {
            string[] states = { "Alabama", "Alaska", "American Samoa", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "District Of Columbia", "Federated States Of Micronesia", "Florida", "Georgia", "Guam", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Marshall Islands", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Northern Mariana Islands", "Ohio", "Oklahoma", "Oregon", "Palau", "Pennsylvania", "Puerto Rico", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virgin Islands", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };
            //await Task.Delay(rnd.Next(1000, 4000));

            var state = states.ElementAt(rnd.Next(1, 58));


            return state;
        }

        public async Task<DateTime> GetARandomDate()
        {
            //await Task.Delay(rnd.Next(1000, 4000));

            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }
    }
}
