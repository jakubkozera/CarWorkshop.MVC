using CarWorkshop.Application.ApplicationUser;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace CarWorkshop.Application.Tests.ApplicationUser
{
    public class UserContextTests
    {
        [Fact]
        public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
        {
            // Arrange
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Email, "test@example.com"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User")
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "TestAuthentication"));

            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            httpContextAccessor.Setup(x => x.HttpContext).Returns(new DefaultHttpContext
            {
                User = user
            });

            var userContext = new UserContext(httpContextAccessor.Object);

            // Act
            var currentUser = userContext.GetCurrentUser();

            // Assert
            currentUser.Should().NotBeNull();
            currentUser!.Id.Should().Be("1");
            currentUser.Email.Should().Be("test@example.com");
            currentUser.Roles.Should().ContainInOrder("Admin", "User");
        }

        [Fact]
        public void GetCurrentUser_WithNonAuthenticatedUser_ShouldReturnNull()
        {
            // Arrange
            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            httpContextAccessor.Setup(x => x.HttpContext).Returns(new DefaultHttpContext());

            var userContext = new UserContext(httpContextAccessor.Object);

            // Act
            var currentUser = userContext.GetCurrentUser();

            // Assert
            currentUser.Should().BeNull();
        }

        [Fact]
        public void GetCurrentUser_WithoutHttpContext_ShouldThrowException()
        {
            // Arrange
            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            httpContextAccessor.Setup(x => x.HttpContext).Returns((HttpContext)null);

            var userContext = new UserContext(httpContextAccessor.Object);

            // Act
            var action = new Action(() => userContext.GetCurrentUser());

            // Assert
            action.Should().Throw<InvalidOperationException>().WithMessage("Context user is not present");
        }
    }
}
