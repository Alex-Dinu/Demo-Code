using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUi.Services;

namespace WebUi.Controllers
{
    public class ClosuresController : BaseServiceController
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}