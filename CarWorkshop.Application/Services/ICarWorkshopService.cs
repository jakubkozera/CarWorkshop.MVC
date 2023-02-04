using CarWorkshop.Application.CarWorkshop;

namespace CarWorkshop.Application.Services
{
    public interface ICarWorkshopService
    {
        Task Create(CarWorkshopDto carWorkshop);
        Task<IEnumerable<CarWorkshopDto>> GetAll();
    }
}