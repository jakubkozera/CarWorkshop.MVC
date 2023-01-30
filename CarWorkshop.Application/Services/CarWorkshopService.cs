using CarWorkshop.Domain.Interfaces;

namespace CarWorkshop.Application.Services
{
    public class CarWorkshopService : ICarWorkshopService
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;

        public CarWorkshopService(ICarWorkshopRepository carWorkshopRepository)
        {
            _carWorkshopRepository = carWorkshopRepository;
        }
        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            carWorkshop.EncodeName();

            await _carWorkshopRepository.Create(carWorkshop);
        }
    }
}
