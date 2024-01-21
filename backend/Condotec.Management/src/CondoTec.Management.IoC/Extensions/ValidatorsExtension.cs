using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CondoTec.Management.Application.Responses;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using CondoTec.Management.Application.Commands.Condominios.UseCases.AddCondominio;
using CondoTec.Management.Application.Commands.Condominios.Validator;
using System.Net;

namespace CondoTec.Management.IoC.Extensions
{
    public static class ValidatorExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(x => x.DisableDataAnnotationsValidation = true);
            services.AddScoped<IValidator<AddCondominioCommand>, CondominioValidator>();
            return services;
        }
    }

    public class ValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                        .SelectMany(v => v.Errors)
                        .Select(v => v.ErrorMessage)
                        .ToList();

                context.Result = new JsonResult(new ApiResponse
                {
                    ErrorMessages = errors,
                    StatusCode = HttpStatusCode.BadRequest
                })
                {
                    StatusCode = 400
                };
            }
        }
    }
}
