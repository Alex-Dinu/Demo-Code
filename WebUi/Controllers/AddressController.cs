using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUi.Services;
using WebUi.Services.CustomerAddress;

namespace WebUi.Controllers
{
    public class AddressController : BaseServiceController
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerSearch/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerAddressMvcRequestModel customerAddressMvcRequestData)
        {
            try
            {
                // TODO: Add insert logic here
                return null;
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}