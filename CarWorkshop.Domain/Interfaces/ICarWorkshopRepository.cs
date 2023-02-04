namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopRepository
    {
        Task Create(Domain.Entities.CarWorkshop carWorkshop);
        Task<Domain.Entities.CarWorkshop?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAll();
    }
}
