using Application.UseCases.ExchangeRates;
using Newtonsoft.Json;
using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ExchangeRates
{
    public interface IExchangeRateApi
    {
        Task<ExchangeRateApplicationResponseModel> GetUsGbExchangeRate();
    }

    public class ExchangeRateApi : IExchangeRateApi
    {
        private string _uri = "https://api.exchangeratesapi.io";
        private string _requestUri = "/latest?symbols=USD,GBP";


        public async Task<ExchangeRateApplicationResponseModel> GetUsGbExchangeRate()
        {
            using (MiniProfiler.Current.Step("Getting the Exchange Rates"))
            {

                var apiData = GetApiCallData().Result;


                    var data = JsonConvert.DeserializeObject
                        <ExchangeRateApplicationApiResponseModel>(apiData);

                    var returnData = MiniProfiler.Current.Inline(
                        () => GetOutput(data), "Mapping the output");
                    return returnData;
            }
        }


        private async Task<string> GetApiCallData()
        {
            using (CustomTiming timing = MiniProfiler.Current.CustomTiming("http", string.Empty, "GET"))
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_uri);
                    MediaTypeWithQualityHeaderValue contentType =
                        new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    HttpResponseMessage response = client.GetAsync(_requestUri).Result;
                    string stringData = response.Content.ReadAsStringAsync().Result;

                    timing.CommandString = $"URL: {_uri + _requestUri} \n\nRESPONSE CODE: {response.StatusCode}";
                    return stringData;

                }
            }

        }
            private ExchangeRateApplicationResponseModel GetOutput(ExchangeRateApplicationApiResponseModel responseData)
        {
            ExchangeRateApplicationResponseModel exchangeRateApplicationResponseData =
                new ExchangeRateApplicationResponseModel()
                {
                    ExchangeRateDate = responseData.Date,
                    GBP = responseData.Rates.Where(r=>r.Key == "GBP").Select(r => r.Value).FirstOrDefault(),
                    USD = responseData.Rates.Where(r => r.Key == "USD").Select(r => r.Value).FirstOrDefault()
                };
            return exchangeRateApplicationResponseData;
        }

    }


}
