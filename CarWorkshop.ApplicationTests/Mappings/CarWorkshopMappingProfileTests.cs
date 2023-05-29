using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshopService;
using CarWorkshop.Application.Mappings;
using CarWorkshop.Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace CarWorkshop.Application.Tests
{
    public class CarWorkshopMappingProfileTests
    {
        [Fact]
        public void MappingProfile_ShouldMapCarWorkshopDtoToCarWorkshop()
        {
            // Arrange
            var userContext = MockUserContext();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new CarWorkshopMappingProfile(userContext.Object)));
            var mapper = configuration.CreateMapper();
            var dto = new CarWorkshopDto
            {
                City = "City",
                PhoneNumber = "123456789",
                PostalCode = "12345",
                Street = "Street"
            };

            // Act
            var result = mapper.Map<Domain.Entities.CarWorkshop>(dto);

            // Assert
            result.Should().NotBeNull();
            result.ContactDetails.Should().NotBeNull();
            result.ContactDetails.City.Should().Be(dto.City);
            result.ContactDetails.PhoneNumber.Should().Be(dto.PhoneNumber);
            result.ContactDetails.PostalCode.Should().Be(dto.PostalCode);
            result.ContactDetails.Street.Should().Be(dto.Street);
        }

        [Fact]
        public void MappingProfile_ShouldMapCarWorkshopToCarWorkshopDto()
        {
            // Arrange
            var userContext = MockUserContext();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new CarWorkshopMappingProfile(userContext.Object)));
            var mapper = configuration.CreateMapper();
            var carWorkshop = new Domain.Entities.CarWorkshop
            {
                Id = 1,
                CreatedById = "1",
                ContactDetails = new CarWorkshopContactDetails
                {
                    City = "City",
                    PhoneNumber = "123456789",
                    PostalCode = "12345",
                    Street = "Street"
                }
            };

            // Act
            var result = mapper.Map<CarWorkshopDto>(carWorkshop);

            // Assert
            result.Should().NotBeNull();
            result.IsEditable.Should().BeTrue();
            result.Street.Should().Be(carWorkshop.ContactDetails.Street);
            result.City.Should().Be(carWorkshop.ContactDetails.City);
            result.PostalCode.Should().Be(carWorkshop.ContactDetails.PostalCode);
            result.PhoneNumber.Should().Be(carWorkshop.ContactDetails.PhoneNumber);
        }

        [Fact]
        public void MappingProfile_ShouldMapCarWorkshopServiceDtoToCarWorkshopService()
        {
            // Arrange
            var userContext = MockUserContext();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new CarWorkshopMappingProfile(userContext.Object)));
            var mapper = configuration.CreateMapper();
            var dto = new CarWorkshopServiceDto
            {
                Cost = "10 PLN",
                Description = "Service description"
            };

            // Act
            var result = mapper.Map<Domain.Entities.CarWorkshopService>(dto);

            // Assert
            result.Should().NotBeNull();
            result.Cost.Should().Be(dto.Cost);
            result.Description.Should().Be(dto.Description);
        }

        [Fact]
        public void MappingProfile_ShouldMapCarWorkshopServiceToCarWorkshopServiceDto()
        {
            // Arrange
            var userContext = MockUserContext();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new CarWorkshopMappingProfile(userContext.Object)));
            var mapper = configuration.CreateMapper();
            var carWorkshopService = new Domain.Entities.CarWorkshopService
            {
                Cost = "10 PLN",
                Description = "Service description"
            };

            // Act
            var result = mapper.Map<CarWorkshopServiceDto>(carWorkshopService);

            // Assert
            result.Should().NotBeNull();
            result.Cost.Should().Be(carWorkshopService.Cost);
            result.Description.Should().Be(carWorkshopService.Description);
        }

        private Mock<IUserContext> MockUserContext()
        {
            var userContext = new Mock<IUserContext>();
            userContext.Setup(c => c.GetCurrentUser()).Returns(new CurrentUser("1", "test@example.com", new[] { "Moderator" }));
            return userContext;
        }
    }
}
