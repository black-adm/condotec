using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CondoTec.Management.Application.Claims
{
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter)) =>
            Arguments = [new Claim(claimType, claimValue)];
    }

    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        readonly Claim _claim;

        public ClaimRequirementFilter(Claim claim) =>
            _claim = claim;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User is not ClaimsPrincipal user)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!user.HasClaim(_claim.Type, _claim.Value))
                context.Result = new ForbidResult();
        }
    }
}
