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

namespace WebUi.Services.Orders
{
    [Route("v1/demo/orders")]
    [ApiController]

    public class OrdersController: BaseServiceController
    {
        IMapper _mapper;
        IClientOrder _clientOrder;

        public OrdersController(IMapper mapper
            , IClientOrder clientOrder
            , IDataLogger dataLogger)
        {
            _mapper = mapper;
            _clientOrder = clientOrder;
            base.DataLogger = dataLogger;
        }

        [HttpGet("{clientId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ErrorResponseModel), 409)]
        [ProducesResponseType(typeof(ClientOrderServiceResponseModel), 200)]
        public async Task<ActionResult<List<ClientOrderServiceResponseModel>>> GetClientOrders(int clientId)
        {
            base.DataLogger.LogInformation("Get Client Orders", clientId);


            try
            {
                var applicationClientOrders = await _clientOrder.GetClientOrders(clientId);
                if (applicationClientOrders == null)
                {
                    return NotFound();
                }

                var responseClientOrders =  _mapper.Map<List<ClientOrderServiceResponseModel>>(applicationClientOrders);


                return Ok(responseClientOrders);
            }
            catch (Exception ex)
            {
                base.DataLogger.LogError(ex);
                return BadRequest(base.GetResponseObject(Constants.ERROR_RESPONSE, Constants.ERROR_RESPONSE));

            }
        }

    }
}
