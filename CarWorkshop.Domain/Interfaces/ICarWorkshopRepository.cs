namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopRepository
    {
        Task Create(Domain.Entities.CarWorkshop carWorkshop);
    }
}
