using Condotec.Identity.Application.Requests;
using Condotec.Identity.Application.Responses;
using System.Security.Claims;

namespace Condotec.Identity.Application.Services
{
    public interface IIdentityService
    {
        Task<ApiResponse> SignUpAsync(SignUpUserRequest usuarioCadastro);
        Task<ApiResponse<UserLoginResponse>> LoginAsync(SignInUserRequest usuarioLogin);
        Task<ApiResponse> AddUserInClaimAsync(AddUserInClaimRequest userInClaim);
        Task<IEnumerable<Claim>> GetUserClaimsAsync(string email);
        Task<ApiResponse<UserLoginResponse>> LoginWithoutPasswordAsync(string usuarioId);
    }
}
