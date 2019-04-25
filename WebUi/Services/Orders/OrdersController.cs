using Application.Shared.Exceptions;
using Application.UseCases.GetClientOrders;
using Application.UseCases.GetOrder;
using AutoMapper;
using Infrastructure.Log;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUi.Middleware.ExceptionResponse;
using WebUi.Models;
using WebUi.Shared;

namespace WebUi.Services.Orders
{
    [Route("v1/demo/orders")]
    [ApiController]

    public class OrdersController: BaseServiceController
    {
        IMapper _mapper;
        IClientOrder _clientOrder;
        IOrder _order;

        public OrdersController(IMapper mapper
            , IClientOrder clientOrder
            , IDataLogger dataLogger
            , IOrder order)
        {
            _mapper = mapper;
            _clientOrder = clientOrder;
            base.DataLogger = dataLogger;
            _order = order;
        }

        /// <summary>
        /// Retrieve an order.
        /// </summary>
        /// <param name="clientId">The orderId to retrieve.</param>
        /// <returns></returns>
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

        [HttpGet("{clientId}/{orderId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(OrderMvcResponseModel), 200)]

        public async Task<ActionResult<OrderMvcResponseModel>> Details(int clientId, int orderId)
        {
            try
            {
                var applicationOrder = await _order.GetOrder(clientId, orderId);
                var order = _mapper.Map<OrderMvcResponseModel>(applicationOrder);

                if (order == null)
                    return NotFound();

                return Ok(order);
            }
            catch (ClientOrderAuthorizationException authEx)
            {
                return Unauthorized(authEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
    }


}
