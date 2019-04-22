using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Application.UseCases.SearchCustomerByName;
using AutoMapper;
using Infrastructure.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUi.Middleware.ExceptionResponse;
using WebUi.Models;
using WebUi.Shared;

namespace WebUi.Controllers
{
    public class CustomerSearchController : BaseController
    {
        private IDataLogger _dataLogger;
        private ICustomerSearch _customerSearch;
        private IMapper _mapper;
        private HtmlEncoder _htmlEncoder;

        public CustomerSearchController(IDataLogger dataLogger
            , ICustomerSearch customerSearch
            , IMapper mapper
            , HtmlEncoder htmlEncoder)
        {
            _htmlEncoder = htmlEncoder;
            _mapper = mapper;
            _customerSearch = customerSearch;
            _dataLogger = dataLogger;
        }

        private async Task<List<CustomerSearchMvcResponseModel>> GetCustomers(string name)
        {
            name = string.IsNullOrEmpty(name) ? "a" : name;
            var customers = await _customerSearch.GetCustomersByName(name);
            var viewCustomers = _mapper.Map<List<CustomerSearchMvcResponseModel>>(customers);
            return viewCustomers;

        }
        // GET: CustomerSearch
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerSearchMvcResponseModel>>> Index()
        {
            _dataLogger.LogInformation("In WebUi.Controllers.CustomerSearchControllerIndex()");

            try
            {
                return View(await GetCustomers(string.Empty));
            }
            catch (Exception ex)
            {
                _dataLogger.LogError(ex);
                return BadRequest(base.GetResponseObject(Constants.ERROR_RESPONSE, Constants.ERROR_RESPONSE));


            }
        }

        // GET: CustomerSearch/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: CustomerSearch/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerSearch/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerSearch/Edit/5
        [HttpGet]

        public async Task<ActionResult<CustomerSearchMvcResponseModel>> Edit(int customerId)
        {
            var customers = await GetCustomers(string.Empty);
            var customer = customers.FirstOrDefault(c => c.CustomerID == customerId);

            return View(customer);

        }

        // POST: CustomerSearch/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerSearchMvcResponseModel customerSearchMvcResponseData)
        {

            if (ModelState.IsValid)
            {
                customerSearchMvcResponseData.CustomerName = _htmlEncoder.Encode(customerSearchMvcResponseData.CustomerName);
                // Update the employee...
                // Display a confirmation and redirect to a better view.
                return RedirectToAction("Index");
            }
            return View(customerSearchMvcResponseData);

        }

        //// GET: CustomerSearch/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CustomerSearch/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [ApiExplorerSettings(IgnoreApi = true)]
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> PhoneNumberIsUnique(string phoneNumber)
        {
            var customers = await GetCustomers(string.Empty);
            var customerWithTheSameLogon = customers.FirstOrDefault(c => c.PhoneNumber == phoneNumber);

            return customerWithTheSameLogon == null
                ? Json(true)
                : Json("Phone number already exists.");
        }
    }
}