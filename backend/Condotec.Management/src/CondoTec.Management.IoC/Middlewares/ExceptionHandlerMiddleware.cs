using CondoTec.Management.Application.Responses;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using SpendManagement.Contracts.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CondoTec.Management.IoC.Middlewares
{
    public class ExceptionHandlerMiddleware(RequestDelegate next, ILogger logger) : AbstractExceptionHandlerMiddleware(next, logger)
    {
        private readonly ILogger _logger = logger;

        public override (HttpStatusCode code, string message) GetResponse(Exception exception)
        {
            var code = exception switch
            {
                NotFoundException => HttpStatusCode.NotFound,
                InternalServerErrorException => HttpStatusCode.InternalServerError,
                ValidationException => HttpStatusCode.BadRequest,
                UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                HttpRequestException => HttpStatusCode.InternalServerError,
                _ => HttpStatusCode.InternalServerError,
            };

            _logger.Error(exception, "The following error occurred ");

            return (code, JsonConvert.SerializeObject(new ApiResponse 
            {
                ErrorMessages = [exception.Message],
            }));
        }
    }
}
