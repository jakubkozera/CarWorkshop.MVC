using CarWorkshop;
using FluentAssertions;

namespace CarWorkshop.Domain.Tests.Entities
{
    public class CarWorkshopTests
    {
        [Fact]
        public void EncodeName_ShouldSetEncodedName()
        {
            // Arrange
            var carWorkshop = new Domain.Entities.CarWorkshop();
            carWorkshop.Name = "Test Workshop";

            // Act
            carWorkshop.EncodeName();

            // Assert
            carWorkshop.EncodedName.Should().Be("test-workshop");
        }

        [Fact]
        public void EncodeName_ShouldThrowException_WhenNameIsNull()
        {
            // Arrange
            var carWorkshop = new Domain.Entities.CarWorkshop();

            // Act
            Action action = () => carWorkshop.EncodeName();

            // Assert
            action.Invoking(a => a.Invoke())
                .Should().Throw<NullReferenceException>();
        }

    }
}
