using CarWorkshop.Application.CarWorkshopService.Commands;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

namespace CarWorkshop.Application.Tests.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandValidatorTests
    {
        [Fact]
        public void Validate_WithValidCommand_ShouldNotHaveValidationError()
        {
            // Arrange
            var validator = new CreateCarWorkshopServiceCommandValidator();
            var command = new CreateCarWorkshopServiceCommand
            {
                Cost = "100 PLN",
                Description = "Service description",
                CarWorkshopEncodedName = "workshop1"
            };

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_WithInvalidCommand_ShouldHaveValidationErrors()
        {
            // Arrange
            var validator = new CreateCarWorkshopServiceCommandValidator();
            var command = new CreateCarWorkshopServiceCommand
            {
                Cost = "",
                Description = "",
                CarWorkshopEncodedName = ""
            };

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(s => s.Cost);
            result.ShouldHaveValidationErrorFor(s => s.Description);
            result.ShouldHaveValidationErrorFor(s => s.CarWorkshopEncodedName);
        }
    }
}
