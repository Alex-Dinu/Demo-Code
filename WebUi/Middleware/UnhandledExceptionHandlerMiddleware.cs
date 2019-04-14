using Infrastructure.Log;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUi.Middleware.ExceptionResponse;
using WebUi.Shared;

namespace WebUi.Middleware
{
    public interface IUnhandledExceptionHandlerMiddleware
    {
        Task Invoke(HttpContext httpContext, IDataLogger dataLogger);
    }

    public class UnhandledExceptionHandlerMiddleware : IUnhandledExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionResponse _exceptionResponse;

        public UnhandledExceptionHandlerMiddleware(RequestDelegate next, IExceptionResponse exceptionResponse)
        {
            _next = next;
            _exceptionResponse = exceptionResponse;

        }

        public async Task Invoke(HttpContext context, IDataLogger dataLogger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //if (context.Response.HasStarted)
                //{
                LogTheException(ex, dataLogger);
                //     throw;
                //}

                var errorResponse = BuildErrorResponse(dataLogger);
                await _exceptionResponse.SendExceptionResponse(context, 500, errorResponse);

                return;

            }
        }

        private static ErrorResponseModel BuildErrorResponse(IDataLogger dataLogger)
        {

            ErrorResponseModel errorResponse = new ErrorResponseModel
            {
                Name = Constants.ERROR_RESPONSE,
                DebugId = dataLogger.Id,
                Message = "An error has occured.",
            };
            return errorResponse;
        }


        private void LogTheException(Exception ex, IDataLogger dataLogger)
        {
            dataLogger.LogError(ex);
        }
    }

}
