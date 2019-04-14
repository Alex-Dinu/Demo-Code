using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUi.Middleware.ExceptionResponse
{
    public interface IExceptionResponse
    {
        Task SendExceptionResponse(HttpContext context, int statusCode, ErrorResponseModel errorResponse);
    }

    public class ExceptionResponse : IExceptionResponse
    {
        public async Task SendExceptionResponse(HttpContext context, int statusCode, ErrorResponseModel errorResponse)
        {
            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));

        }
    }

}
