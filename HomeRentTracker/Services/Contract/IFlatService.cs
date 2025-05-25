using HomeRentTracker.Models.FlatEntity;

namespace HomeRentTracker.Services.Contract
{
    public interface IFlatService
    {
        Task<IEnumerable<Flat>> GetAllFlatsAsync();
        Task<Flat> GetFlatByIdAsync(int id);
        Task InsertFlatAsync(Flat flat);
        Task UpdateFlatAsync(Flat flat);
        Task DeleteFlatAsync(int id);
    }
}
