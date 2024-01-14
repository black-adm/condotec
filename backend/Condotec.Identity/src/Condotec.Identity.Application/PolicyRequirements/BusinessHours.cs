using Microsoft.AspNetCore.Authorization;

namespace Condotec.Identity.Application.PolicyRequirements
{
    public class BusinessHours : AuthorizationHandler<BusinessHourRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BusinessHourRequirement requirement)
        {
            var horarioAtual = TimeOnly.FromDateTime(DateTime.Now);
            if (horarioAtual.Hour >= 8 && horarioAtual.Hour <= 18)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
