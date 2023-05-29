using Microsoft.AspNetCore.Mvc.Testing;
using MediatR;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using CarWorkshop.Application.CarWorkshop;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;

namespace YourApp.Tests.Integration
{
    public class CarWorkshopControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CarWorkshopControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Index_ReturnsViewWithExpectedData_ForExistingWorkshops()
        {
            // Arrange
            var carWorkshops = new List<CarWorkshopDto>
            {
                new () { Name = "Workshop 1" },
                new () { Name = "Workshop 2" },
                new () { Name = "Workshop 3" }
            };

            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(mediator => mediator.Send(It.IsAny<GetAllCarWorkshopsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(carWorkshops);

            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped(_ => mockMediator.Object);
                });
            }).CreateClient();

            // Act
            var response = await client.GetAsync("/CarWorkshop/Index");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            content.Should().Contain("<h1>Car Workshops</h1>")
                .And.Contain("Workshop 1")
                .And.Contain("Workshop 2")
                .And.Contain("Workshop 3");
        }

        [Fact]
        public async Task Index_ReturnsEmptyView_WhenNoCarWorkshopsExist()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(mediator => mediator.Send(It.IsAny<GetAllCarWorkshopsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<CarWorkshopDto>());

            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped(_ => mockMediator.Object);
                });
            }).CreateClient();

            // Act
            var response = await client.GetAsync("/CarWorkshop/Index");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            content.Should().NotContain("div class=\"card m-3\"");
        }
    }
}
