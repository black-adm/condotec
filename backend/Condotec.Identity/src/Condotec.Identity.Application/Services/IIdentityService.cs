using Condotec.Identity.Application.Requests;
using Condotec.Identity.Application.Responses;
using System.Security.Claims;

namespace Condotec.Identity.Application.Services
{
    public interface IIdentityService
    {
        Task<UserResponse> SignUpAsync(SignUpUserRequest usuarioCadastro);
        Task<UserLoginResponse> LoginAsync(SignInUserRequest usuarioLogin);
        Task<UserResponse> AddUserInClaimAsync(AddUserInClaimRequest userInClaim);
        Task<IEnumerable<Claim>> GetUserClaimsAsync(string email);
        Task<UserLoginResponse> LoginWithoutPasswordAsync(string usuarioId);
    }
}
