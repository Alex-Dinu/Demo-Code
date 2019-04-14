using Infrastructure.Log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUi.Middleware.ExceptionResponse;
using WebUi.Shared;

namespace WebUi.Services
{

    public class BaseServiceController : Controller
    {
               
        public IDataLogger DataLogger;
        [NonAction]
        public string GetHeaderKeyValue(string headerKey)
        {
            string returnValue = Request.Headers[headerKey];
            if (string.IsNullOrEmpty(returnValue))
                throw new NullReferenceException("Could not find " + headerKey + " in the header collection");

            //DataLogger.LogArrayInformation(headerKey, new object{headerKey= returnValue});

            return returnValue;
        }

        [NonAction]
        public BadRequestObjectResult GenerateModelValidationBadRequest(ModelStateDictionary modelState, string location = "body")
        {
            ErrorResponseDetailModel errorResponseDetail;
            List<ErrorResponseDetailModel> errorResponseDetails = new List<ErrorResponseDetailModel>();

            foreach (var state in modelState)
            {
                string field = state.Key;
                var issue = string.Empty;
                foreach (var error in state.Value.Errors)
                {
                    issue += error.ErrorMessage;
                }

                errorResponseDetail = new ErrorResponseDetailModel { Field = field, Issue = issue, Location = location };
                errorResponseDetails.Add(errorResponseDetail);
            }

            return BadRequest(new ErrorResponseModel
            {
                Name = Constants.VALIDATION_ERROR,
                ErrorDetails = errorResponseDetails,
                DebugId = DataLogger.Id,
                Message = "Invalid data provided"
            });

        }

        [NonAction]
        public BadRequestObjectResult GenerateModelValidationBadRequest(string field, string issue, string location = "body")
        {
            ErrorResponseDetailModel errorResponseDetail = new ErrorResponseDetailModel()
            {
                Field = field,
                Issue = issue,
                Location = location

            };

            List<ErrorResponseDetailModel> errorResponseDetails = new List<ErrorResponseDetailModel>
            {
                errorResponseDetail
            };


            return BadRequest(new ErrorResponseModel
            {
                Name = Constants.VALIDATION_ERROR,
                ErrorDetails = errorResponseDetails,
                DebugId = DataLogger.Id,
                Message = "Invalid data provided"
            });

        }

        [NonAction]
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
