using Application.UseCases.GetClientOrders;
using AutoMapper;
using Infrastructure.Log;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUi.Middleware.ExceptionResponse;
using WebUi.Shared;

namespace WebUi.Services.ChicagoWeather
{
    [Route("v1/demo/chicagoweather")]
    [ApiController]
    public class ChicagoWeatherController : BaseServiceController
    {
        public async Task<IActionResult> GetChicagoWeather()
        {
            return Ok("Cold, what else can it be?");
        }
    }
}
