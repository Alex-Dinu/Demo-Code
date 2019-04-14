using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
namespace WebUi.Middleware
{
    public interface IRequestResponseLoggingMiddleware
    {
        Task Invoke(HttpContext context, IDataLogger dataLogger);
    }

    public class RequestResponseLoggingMiddleware : IRequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        // Middleware: Custom middleware types need to have a constructor taking a RequestDelegate argument
        //             that is used to call the next piece of the middleware pipeline.
        //
        //              This constructor is called once at app startup, so any arguments provided by dependency injection
        //              will be scoped for the lifetime of the application. If DI-provided objects should be scoped more
        //              narrowly, they can be included in the Invoke method's signature.
        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Middleware: Custom middleware needs an Invoke method that is called when requests come in for processing.
        //             It should have an HttpContext as its first argument and, optionally, other services that are
        //             needed from DI. Dependencies which are injected at this level will be scoped to the lifetime of the request.
        public async Task Invoke(HttpContext context, IDataLogger dataLogger)
        {
            try
            {


                //First, get the incoming request
                var request = await FormatRequest(context.Request);

                dataLogger.LogInformation("Request", request);
                dataLogger.LogInformation("RequestHeader", FormatHeaders(context.Request));

                //Copy a pointer to the original response body stream
                var originalBodyStream = context.Response.Body;

                //Create a new memory stream...
                using (var responseBody = new MemoryStream())
                {
                    //...and use that for the temporary response body
                    context.Response.Body = responseBody;

                    //Continue down the Middleware pipeline, eventually returning to this class
                    await _next(context);

                    //Format the response from the server
                    var response = await FormatResponse(context.Response);

                    dataLogger.LogInformation("Response", response);
                    //Copy the contents of the new memory stream (which contains the response) to the original stream, which is then returned to the client.
                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
            catch (Exception)
            {
                // Do nothing. We don't want to stop execution.
                await _next(context);
            }

        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;

            //This line allows us to set the reader for the request back at the beginning of its stream.
            request.EnableRewind();

            //We now need to read the request stream.  First, we create a new byte[] with the same length as the request stream...
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            //...Then we copy the entire request stream into the new buffer.
            await request.Body.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);

            //We convert the byte[] into a string using UTF8 encoding...
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            //..and finally, assign the read body back to the request body, which is allowed because of EnableRewind()
            //request.Body = body;
            request.Body.Seek(0, SeekOrigin.Begin);
            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

        private string FormatHeaders(HttpRequest request)
        {
            string headers = "{";
            foreach (var header in request.Headers)
                headers += $@"""{header.Key}"":""{header.Value}"",";

            headers += "}";
            return $"{headers}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            //We need to read the response stream from the beginning...
            response.Body.Seek(0, SeekOrigin.Begin);

            //...and copy it into a string
            string text = await new StreamReader(response.Body).ReadToEndAsync();

            //We need to reset the reader for the response so that the client can read it.
            response.Body.Seek(0, SeekOrigin.Begin);

            //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
            return $"{response.StatusCode}: {text}";
        }
    }

}
