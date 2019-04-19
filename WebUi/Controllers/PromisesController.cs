using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUi.Services;

namespace WebUi.Controllers
{
    public class PromisesController : BaseServiceController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}