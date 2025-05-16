using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                await _dbContext.Database.EnsureCreatedAsync();

                // Check if Mazda ASO already exists
                if (!await _dbContext.CarWorkshops.AnyAsync(cw => cw.Name == "Mazda ASO"))
                {
                    // Add seed data
                    var mazdaAso = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Mazda ASO",
                        Description = "Mazda Authorized Service Outlet",
                        ContactDetails = new()
                        {
                            City = "Kraków",
                            Street = "Szewska 2",
                            PostalCode = "30-001",
                            PhoneNumber = "+48699222888"
                        }
                    };
                    mazdaAso.EncodeName();

                    mazdaAso.Services = new List<Domain.Entities.CarWorkshopService>()
                    {
                        new Domain.Entities.CarWorkshopService()
                        {
                            Description = "Mazda 3 fluid change",
                            Cost = "$ 500",
                            CarWorkshop = mazdaAso
                        },
                        new Domain.Entities.CarWorkshopService()
                        {
                            Description = "Mazda 3 full service",
                            Cost = "$ 700",
                            CarWorkshop = mazdaAso
                        },
                        new Domain.Entities.CarWorkshopService()
                        {
                            Description = "Mazda 6 full service",
                            Cost = "$ 900",
                            CarWorkshop = mazdaAso
                        }
                    };

                    _dbContext.CarWorkshops.Add(mazdaAso);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
