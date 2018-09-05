using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            string requestAsString = await ReadAndFormatRequest(context.Request);

            logger.LogInformation(requestAsString);            

            await next(context);
        }

        private async Task<string> ReadAndFormatRequest(HttpRequest request)
        {
            request.EnableBuffering();

            var headers = request.Headers.Select(x => $"{x.Key}: {x.Value}");
            var headersAsString = string.Join(Environment.NewLine, headers);

            var reader = new StreamReader(request.Body);

            string bodyAsString = await reader.ReadToEndAsync();

            request.Body.Seek(0, SeekOrigin.Begin);

            return $"{request.Method} {request.Path} {request.Protocol}{Environment.NewLine}{headersAsString}{Environment.NewLine}{bodyAsString}";
        }
    }
}
