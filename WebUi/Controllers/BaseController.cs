using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Log;
using Microsoft.AspNetCore.Mvc;
using WebUi.Middleware.ExceptionResponse;

namespace WebUi.Controllers
{
    public class BaseController: Controller
    {
        public IDataLogger DataLogger;

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ErrorResponseModel GetResponseObject(string name, string message)
        {
            var response = new ErrorResponseModel
            {
                Name = name,
                ErrorDetails = null,
                DebugId = DataLogger.Id,
                Message = message
            };

            return response;
        }
    }
}
