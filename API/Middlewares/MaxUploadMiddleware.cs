using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using API.Errors;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Features;

namespace API.MiddleWares
{
    public class MaxUploadMiddleware
    {
        private readonly IHostEnvironment _evn;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;

        public MaxUploadMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
        IHostEnvironment env)
        {
            _evn = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //Max Video upload size 30MB
            if (context.Request.Path.StartsWithSegments("/api/lesson/updatevideo"))
            {
                context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = 30000000;
            };

            await _next(context);
        }
    }
}