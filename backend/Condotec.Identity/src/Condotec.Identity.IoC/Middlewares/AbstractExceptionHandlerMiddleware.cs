﻿using Microsoft.AspNetCore.Http;
using Serilog;
using System.Net;

namespace Condotec.Infra.CrossCutting.Middlewares
{
    public abstract class AbstractExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public abstract (HttpStatusCode code, string message) GetResponse(Exception exception);

        protected AbstractExceptionHandlerMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                // log the error
                _logger.Error(exception, "error during executing", context.Request.Path.Value);
                var response = context.Response;
                response.ContentType = "application/json";

                // get the response code and message
                var (status, message) = GetResponse(exception);
                response.StatusCode = (int)status;
                await response.WriteAsync(message);
            }
        }
    }
}
