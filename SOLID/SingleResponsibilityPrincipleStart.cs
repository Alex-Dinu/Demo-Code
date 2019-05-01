using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SOLID
{
    public class SingleResponsibilityPrincipleStart
    {
        public decimal Rating { get; set; }
        public void Rate()
        {
            Console.WriteLine("Starting ExecuteSomething");

            string policyJson =new PolicyGetter().GetPolicy();

            var policy = JsonConvert.DeserializeObject<Policy>(policyJson, new StringEnumConverter());

            switch (policy.Type)
            {
                case PolicyType.Auto:
                    Console.WriteLine("Rating AUTO policy...");
                    if (policy.Make == "BMW")
                    {
                        if (policy.Deductible < 500)
                        {
                            Rating = 1000m;
                        }
                        Rating = 900m;
                    }
                    break;

                case PolicyType.Land:
                    Console.WriteLine("Rating LAND policy...");
                    if (policy.BondAmount == 0 || policy.Valuation == 0)
                    {
                        Console.WriteLine("Land policy must specify Bond Amount and Valuation.");
                        return;
                    }
                    Rating = policy.BondAmount * 0.05m;
                    break;
                case PolicyType.Life:
                    Console.WriteLine("Rating LIFE policy...");
                    int age = DateTime.Today.Year - policy.DateOfBirth.Year;
                    decimal baseRate = policy.Amount * age / 200;
                    if (policy.IsSmoker)
                    {
                        Rating = baseRate * 2;
                        break;
                    }
                    Rating = baseRate;
                    break;
                default:
                    Console.WriteLine("Unknown policy type");
                    break;

            }

        }
    }

    public class PolicyGetter
    {
        public string GetPolicy()
        {
            return
                "{\r\n  \"type\": \"Land\",\r\n  \"bondAmount\": \"1000000\",\r\n  \"valuation\": \"1100000\"\r\n}\r\n";
        }
    }

    public class Policy
    {
        public PolicyType Type { get; set; }
        #region Life Insurance
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSmoker { get; set; }
        public decimal Amount { get; set; }
        #endregion

        #region Land
        public string Address { get; set; }
        public decimal Size { get; set; }
        public decimal Valuation { get; set; }
        public decimal BondAmount { get; set; }
        #endregion

        #region Auto
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Miles { get; set; }
        public decimal Deductible { get; set; }
        #endregion

    }

    public enum PolicyType
    {
        Life = 0,
        Land = 1,
        Auto = 2
    }
}
