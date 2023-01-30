namespace CarWorkshop.Application.Services
{
    public interface ICarWorkshopService
    {
        Task Create(Domain.Entities.CarWorkshop carWorkshop);
    }
}