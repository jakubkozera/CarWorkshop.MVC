using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshopService.Commands;
using CarWorkshop.Domain.Interfaces;
using FluentAssertions;
using MediatR;
using Moq;
using Xunit;

namespace CarWorkshop.Application.Tests.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandHandlerTests
    {
        [Fact]
        public async Task Handle_WithValidRequestAndEditableUser_ShouldCreateCarWorkshopServiceAndReturnUnit()
        {
            // Arrange
            var carWorkshop = new Domain.Entities.CarWorkshop { Id = 1, CreatedById = "1" };
            var userContext = MockUserContext(true);
            var carWorkshopRepository = MockCarWorkshopRepository(carWorkshop);
            var carWorkshopServiceRepository = new Mock<ICarWorkshopServiceRepository>();
            var handler = new CreateCarWorkshopServiceCommandHandler(userContext.Object, carWorkshopRepository.Object, carWorkshopServiceRepository.Object);
            var command = new CreateCarWorkshopServiceCommand
            {
                Cost = "100 PLN",
                Description = "Service description",
                CarWorkshopEncodedName = "workshop1"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);
            carWorkshopServiceRepository.Verify(r => r.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Once);
        }

        [Fact]
        public async Task Handle_WithInvalidRequestOrNonEditableUser_ShouldReturnUnitWithoutCreatingCarWorkshopService()
        {
            // Arrange
            var carWorkshop = new Domain.Entities.CarWorkshop { Id = 1, CreatedById = "2" };
            var userContext = MockUserContext(false);
            var carWorkshopRepository = MockCarWorkshopRepository(carWorkshop);
            var carWorkshopServiceRepository = new Mock<ICarWorkshopServiceRepository>();
            var handler = new CreateCarWorkshopServiceCommandHandler(userContext.Object, carWorkshopRepository.Object, carWorkshopServiceRepository.Object);
            var command = new CreateCarWorkshopServiceCommand
            {
                Cost = "100 PLN",
                Description = "Service description",
                CarWorkshopEncodedName = "workshop1"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);
            carWorkshopServiceRepository.Verify(r => r.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Never);
        }

        private Mock<IUserContext> MockUserContext(bool isEditable)
        {
            var userContext = new Mock<IUserContext>();
            var user = isEditable ? new CurrentUser("1", "test@example.com", new[] { "Moderator" }) : null;
            userContext.Setup(c => c.GetCurrentUser()).Returns(user);
            return userContext;
        }

        private Mock<ICarWorkshopRepository> MockCarWorkshopRepository(Domain.Entities.CarWorkshop carWorkshop)
        {
            var carWorkshopRepository = new Mock<ICarWorkshopRepository>();
            carWorkshopRepository.Setup(r => r.GetByEncodedName(It.IsAny<string>())).ReturnsAsync(carWorkshop);
            return carWorkshopRepository;
        }
    }
}
