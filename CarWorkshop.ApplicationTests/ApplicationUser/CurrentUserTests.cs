using CarWorkshop.Application.CarWorkshop;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarWorkshop.ApplicationTests.ApplicationUser
{
    public class CurrentUserTests
    {
        [Fact]
        public void IsInRole_WithMatchingRole_ShouldReturnTrue()
        {
            // Arrange
            var currentUser = new CurrentUser("1", "test@example.com", new List<string> { "Admin", "User" });

            // Act
            var isInRole = currentUser.IsInRole("Admin");

            // Assert
            isInRole.Should().BeTrue();
        }

        [Fact]
        public void IsInRole_WithNonMatchingRole_ShouldReturnFalse()
        {
            // Arrange
            var currentUser = new CurrentUser("1", "test@example.com", new List<string> { "Admin", "User" });

            // Act
            var isInRole = currentUser.IsInRole("Manager");

            // Assert
            isInRole.Should().BeFalse();
        }
    }
}
