using Condotec.Identity.Application.Requests;
using Condotec.Identity.Application.Responses;
using Condotec.Identity.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Serilog;

namespace Condotec.Identity.Application.Services
{
    public class IdentityService(SignInManager<IdentityUser> signInManager,
                           UserManager<IdentityUser> userManager,
                           IOptions<JwtOptions> jwtOptions,
                           ILogger logger) : IIdentityService
    {
        private readonly SignInManager<IdentityUser> _signInManager = signInManager;
        private readonly UserManager<IdentityUser> _userManager = userManager;
        private readonly JwtOptions _jwtOptions = jwtOptions.Value;
        private readonly ILogger _logger = logger;

        public async Task<UserResponse> SignUpAsync(SignUpUserRequest usuarioCadastro)
        {
            var identityUser = new IdentityUser
            {
                UserName = usuarioCadastro.Username,
                NormalizedUserName = usuarioCadastro.Username,
                Email = usuarioCadastro.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(identityUser, usuarioCadastro.Password!);

            if (result.Succeeded)
                await _userManager.SetLockoutEnabledAsync(identityUser, false);

            var userSignedResponse = new UserResponse(result.Succeeded);

            if (!result.Succeeded && result.Errors.Any())
                userSignedResponse.AddError(result.Errors.Select(r => r.Description));

            _logger.Information("User created with successfully", usuarioCadastro.Email);

            return userSignedResponse;
        }

        public async Task<UserLoginResponse> LoginAsync(SignInUserRequest usuarioLogin)
        {
            var usuarioLoginResponse = new UserLoginResponse();

            var user = await _userManager.FindByNameAsync(usuarioLogin.Username!);

            if (user is not null)
            {
                var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Username!, usuarioLogin.Password!, false, true);

                if (result.Succeeded)
                    return await GenerateCredentials(user.Email);

                if (!result.Succeeded)
                {
                    usuarioLoginResponse = result switch
                    {
                        _ when result.IsLockedOut.Equals(true) => usuarioLoginResponse.AddErrors("This account is locked."),
                        _ when result.IsNotAllowed.Equals(true) => usuarioLoginResponse.AddErrors("This account is locked."),
                        _ when result.RequiresTwoFactor.Equals(true) => usuarioLoginResponse.AddErrors("This account is locked."),
                        _ => usuarioLoginResponse.AddErrors("User or password incorrect"),
                    };
                }
            }

            usuarioLoginResponse.AddErrors("Username not found");
            return usuarioLoginResponse;
        }

        public async Task<IEnumerable<Claim>> GetUserClaimsAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is not null)
                return await _userManager.GetClaimsAsync(user);

            return Enumerable.Empty<Claim>();
        }

        public async Task<UserResponse> AddUserInClaimAsync(AddUserInClaimRequest userInClaim)
        {
            var user = await _userManager.FindByEmailAsync(userInClaim.Email!);

            if (user != null && userInClaim.Claims?.Any() == true)
            {
                var claimsToAdd = userInClaim.Claims
                    .Select(claim => new Claim(claim.ClaimType.ToString(), claim.ClaimValue.ToString()))
                    .ToList();

                if (claimsToAdd.Count != 0)
                {
                    var identityResult = await _userManager.AddClaimsAsync(user, claimsToAdd);

                    if (identityResult.Succeeded)
                    {
                        _logger.Information("User added in claim with success", userInClaim.Email);
                        return new UserResponse(true);
                    }
                }
            }

            _logger.Information("Failed to add user in claim", userInClaim.Email);
            return new UserResponse(false);
        }

        public async Task<UserLoginResponse> LoginWithoutPasswordAsync(string usuarioId)
        {
            var usuarioLoginResponse = new UserLoginResponse();
            var usuario = await _userManager.FindByIdAsync(usuarioId);

            return _userManager switch
            {
                _ when await _userManager.IsLockedOutAsync(usuario!) => usuarioLoginResponse.AddErrors("This account is locked."),
                _ when !await _userManager.IsEmailConfirmedAsync(usuario!) => usuarioLoginResponse.AddErrors("This account is locked."),
                _ => await GenerateCredentials(usuario!.Email)
            };
        }

        private async Task<UserLoginResponse> GenerateCredentials(string? email)
        {
            var user = await _userManager.FindByEmailAsync(email!);
            var accessTokenClaims = await GetClaims(user!, true);
            var refreshTokenClaims = await GetClaims(user!, false);

            var dataExpiracaoAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
            var dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

            var accessToken = GerarToken(accessTokenClaims, dataExpiracaoAccessToken);
            var refreshToken = GerarToken(refreshTokenClaims, dataExpiracaoRefreshToken);

            _logger.Information("User logged with successfully", email);

            return new UserLoginResponse
            (
                accessToken: accessToken,
                refreshToken: refreshToken
            );
        }

        private string GerarToken(IEnumerable<System.Security.Claims.Claim> claims, DateTime dataExpiracao)
        {
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: dataExpiracao,
                signingCredentials: _jwtOptions.SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private async Task<IList<Claim>> GetClaims(IdentityUser user, bool adicionarClaimsUsuario)
        {
            long iat = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id),
                new(JwtRegisteredClaimNames.Email, user.Email!),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, iat.ToString())
            };

            if (adicionarClaimsUsuario)
            {
                var userClaims = await _userManager.GetClaimsAsync(user);
                var roles = await _userManager.GetRolesAsync(user);

                claims.AddRange(userClaims);

                foreach (var role in roles)
                    claims.Add(new Claim("role", role));
            }

            return claims;
        }
    }
}
