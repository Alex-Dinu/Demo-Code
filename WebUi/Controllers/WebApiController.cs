using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Shared.Exceptions;
using Application.UseCases.GetClientOrders;
using Application.UseCases.GetOrder;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebUi.Models;

namespace WebUi.Controllers
{
    public class WebApiController : BaseController
    {
        IClientOrder _clientOrder;
        IMapper _mapper;
        IOrder _order;

        public WebApiController(IClientOrder clientOrder, IMapper mapper, IOrder order)
        {
            _clientOrder = clientOrder;
            _mapper = mapper;
            _order = order;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderMvcResponseListModel>>> Index()
        {
            var orders = await _clientOrder.GetClientOrders(1009);

            return View(_mapper.Map<List<OrderMvcResponseListModel>>(orders));

        }

        [HttpGet]
        public async Task<ActionResult<OrderMvcResponseModel>> Details(int clientId, int orderId)
        {
            try
            {
                var applicationOrder = await _order.GetOrder(clientId, orderId);
                var order = _mapper.Map<OrderMvcResponseModel>(applicationOrder);
                return View(order);
            }
            catch(ClientOrderAuthorizationException authEx)
            {
                return View(authEx.Message);
            }
            catch(Exception ex)
            {
                return View(ex.Message);

            }

        }
    }
}