using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.GetSomeData;
using Microsoft.AspNetCore.Mvc;

namespace WebUi.Services.SomeData
{
    [Route("v1/demo/somedata")]
    [ApiController]
    public class SomeDataController : BaseServiceController
    {
        public SomeDataController(ISomeDataGetter someDataGetter)
        {
            _someDataGetter = someDataGetter;
        }
        Random rnd = new Random();
        private ISomeDataGetter _someDataGetter;

        [HttpGet("getTemp")]
        public async Task<IActionResult> GetTemperature()
        {
            await Task.Delay(500);
            return Ok(await _someDataGetter.GetTemperature());
        }

        [HttpGet("getStock")]
        public async Task<IActionResult> GetStockPrice()
        {
            await Task.Delay(500);
            return Ok(await _someDataGetter.GetStockPrice());
        }

        [HttpGet("getState")]
        public async Task<IActionResult> GetStateName()
        {
            await Task.Delay(500);
            return Ok(await _someDataGetter.GetStateName());
        }

        [HttpGet("getDate")]
        public async Task<IActionResult> GetARandomDate()
        {
            await Task.Delay(500);

            return Ok(await _someDataGetter.GetARandomDate());
        }
    }
}