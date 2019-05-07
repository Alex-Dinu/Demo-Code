using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.ExchangeRates;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebUi.Models;
using WebUi.Services;
using WebUi.Shared;


namespace WebUi.Controllers
{
    public class ExchangeRateController : BaseServiceController
    {
        private IExchangeRateApi _exchangeRateApi;
        private IMapper _mapper;

        public ExchangeRateController(IExchangeRateApi exchangeRateApi, IMapper mapper)
        {
            _mapper = mapper;
            _exchangeRateApi = exchangeRateApi;
        }
        public async Task<ActionResult<ExchangeRateMvcResponseModel>> Index()
        {
            try
            {
                var appData = await _exchangeRateApi.GetUsGbExchangeRate();
                var data = _mapper.Map<ExchangeRateMvcResponseModel>(appData);

                return View(data);
            }
            catch (Exception ex)
            {
                    return BadRequest(base.GetResponseObject(Constants.ERROR_RESPONSE, Constants.ERROR_RESPONSE));


               
            }
        }
    }
}