namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopRepository
    {
        Task Create(Domain.Entities.CarWorkshop carWorkshop);
        Task<Domain.Entities.CarWorkshop?> GetByName(string name);
    }
}
