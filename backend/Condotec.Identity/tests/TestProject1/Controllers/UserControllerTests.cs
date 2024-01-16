using AutoFixture;
using Condotec.Identity.API.Controllers;
using Condotec.Identity.Application.Requests;
using Condotec.Identity.Application.Responses;
using Condotec.Identity.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using Xunit;

namespace Condotec.Identity.UnitTests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<HttpContext> _httpContext;
        private readonly UserController _userController;
        private readonly Mock<IIdentityService> _identityServiceMock = new();
        private readonly Fixture fixture = new();

        public UserControllerTests()
        {
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "userIdValue"),
            }));

            _httpContext = new Mock<HttpContext>();

            _httpContext
                .Setup(c => c.User)
                .Returns(claimsPrincipal);

            _userController = new UserController(_identityServiceMock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = _httpContext.Object
                }
            };
        }

        [Fact]
        public async Task GivenValidSignUpOnSignUpEndpoint_SignUpMethodShouldBeCalled()
        {
            //Arrange
            var userSignUp = fixture.Create<SignUpUserRequest>();
            var userResponse = fixture.Create<ApiResponse>();

            _identityServiceMock
                .Setup(x => x.SignUpAsync(userSignUp))
                .Returns(Task.FromResult(userResponse));

            //Act
            await _userController.SignUpAsync(userSignUp);

            //Assert
            _identityServiceMock.Verify(x => x.SignUpAsync(userSignUp), Times.Once);
            _identityServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GivenValidLoginOnLoginEndpoint_SignInMethodShouldBeCalled()
        {
            //Arrange
            var userSignIn = fixture.Create<SignInUserRequest>();
            var userResponse = fixture.Create<ApiResponse<UserLoginResponse>>();

            _identityServiceMock
                .Setup(x => x.LoginAsync(userSignIn))
                .Returns(Task.FromResult(userResponse));

            //Act
            await _userController.MakeLoginAsync(userSignIn);

            //Assert
            _identityServiceMock.Verify(x => x.LoginAsync(userSignIn), Times.Once);
            _identityServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GivenValidEmailOnGetUserClaimsEndpoint_GetUserClaimsAsyncShouldBeCalled()
        {
            //Arrange
            var email = fixture.Create<string>();
            var claim1 = new Claim(fixture.Create<string>(), fixture.Create<string>());
            var claim2 = new Claim(fixture.Create<string>(), fixture.Create<string>());

            var claims = new List<Claim> { claim1, claim2 };

            _identityServiceMock
                .Setup(x => x.GetUserClaimsAsync(email))
                .Returns(Task.FromResult(claims.Select(x => x)));

            //Act
            await _userController.GetUserClaimsAsync(email);

            //Assert
            _identityServiceMock.Verify(x => x.GetUserClaimsAsync(email), Times.Once);
            _identityServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GivenValidUserClaimOnAddUserInClaimEndpoint_AddUserInClaimAsyncShouldBeCalled()
        {
            //Arrange
            var userClaim = fixture.Create<AddUserInClaimRequest>();
            var userResponse = fixture.Create<ApiResponse>();

            _identityServiceMock
                .Setup(x => x.AddUserInClaimAsync(userClaim))
                .Returns(Task.FromResult(userResponse));

            //Act
            await _userController.AddUserInClaimAsync(userClaim);

            //Assert
            _identityServiceMock.Verify(x => x.AddUserInClaimAsync(userClaim), Times.Once);
            _identityServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GivenValidRefreshLoginOnRefreshLoginEndpoint_RefreshLoginShouldBeCalled()
        {
            //Arrange
            var identity = _httpContext.Object.User.Identity as ClaimsIdentity;
            var userId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userResponse = fixture.Create<ApiResponse<UserLoginResponse>>();

            _identityServiceMock
                .Setup(x => x.LoginWithoutPasswordAsync(userId!))
                .Returns(Task.FromResult(userResponse));

            //Act
            await _userController.RefreshLoginAsync();

            //Assert
            _identityServiceMock.Verify(x => x.LoginWithoutPasswordAsync(userId!), Times.Once);
            _identityServiceMock.VerifyNoOtherCalls();
        }
    }
}
