using Condotec.Identity.Application.Requests;
using Condotec.Identity.Application.Responses;
using Condotec.Identity.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SpendManagement.Identity.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class UserController(IIdentityService identityService) : Controller
    {
        private readonly IIdentityService _identityService = identityService;

        /// <summary>
        /// SignUp Users
        /// </summary>
        /// <param name="signUp">Datas from signed users</param>
        /// <returns>Returns a created user</returns>
        /// <response code="200">User created with successfully</response>
        /// <response code="400">Validation errors</response>
        /// <response code="500">Internal errors</response>
        [HttpPost]
        [Route("signUp", Name = nameof(SignUpAsync))]
        [ProducesResponseType(typeof(UserLoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SignUpAsync(SignUpUserRequest signUp)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userSignedIn = await _identityService.SignUpAsync(signUp);

            if (userSignedIn.Success)
            {
                return Created("/signUp", userSignedIn);
            }

            return BadRequest(userSignedIn.Errors);
        }

        /// <summary>
        /// User's login by e-mail and password
        /// </summary>
        /// <param name="login">User's login data</param>
        /// <returns>Returns a new JWT</returns>
        /// <response code="200">User logged with sucessfully</response>
        /// <response code="400">Validation errors</response>
        /// <response code="401">Authentication error</response>
        /// <response code="500">Internal error</response>
        [HttpPost]
        [Route("login", Name = nameof(MakeLoginAsync))]
        [ProducesResponseType(typeof(UserLoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserLoginResponse>> MakeLoginAsync([FromBody] SignInUserRequest login)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _identityService.LoginAsync(login);

            if (result.Success)
                return Ok(result);

            return Unauthorized(result.Errors);
        }

        /// <summary>
        /// Add user in claim
        /// </summary>
        /// <param name="userClaim">Claim informations</param>
        /// <returns>Return users in claims</returns>
        /// <response code="201">User logged with sucessfully</response>
        /// <response code="400">Validation errors</response>
        /// <response code="401">Authentication error</response>
        /// <response code="500">Internal error</response>
        [HttpPost]
        [Route("addUserInClaim", Name = nameof(AddUserInClaimAsync))]
        [ProducesResponseType(typeof(UserLoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<bool>> AddUserInClaimAsync([FromBody] AddUserInClaimRequest userClaim)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userClaims = await _identityService.AddUserInClaimAsync(userClaim);
            return Created("addUserInClaim", userClaims);
        }

        /// <summary>
        /// User login by refresh token.
        /// </summary>
        /// <returns>Returns a new JWT refreshed</returns>
        /// <response code="200">User logged with sucessfully</response>
        /// <response code="400">Validation errors</response>
        /// <response code="401">Authentication error</response>
        /// <response code="500">Internal error</response>
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Authorize]
        [HttpPost("refresh-login")]
        public async Task<ActionResult<UserLoginResponse>> RefreshLoginAsync()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var usuarioId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (usuarioId is null)
                return BadRequest();

            var result = await _identityService.LoginWithoutPasswordAsync(usuarioId);
            if (result.Success)
                return Ok(result);

            return Unauthorized();
        }

        /// <summary>
        /// Get user claims
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns>Return users in claims</returns>
        /// <response code="201">User logged with sucessfully</response>
        /// <response code="400">Validation errors</response>
        /// <response code="401">Authentication error</response>
        /// <response code="500">Internal error</response>
        [HttpGet]
        [Route("getUserClaims", Name = nameof(GetUserClaimsAsync))]
        [ProducesResponseType(typeof(UserLoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<bool>> GetUserClaimsAsync(string email)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userClaims = await _identityService.GetUserClaimsAsync(email);

            return Ok(userClaims);
        }
    }
}
