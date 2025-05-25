using FlatRentTracker.Models;

namespace FlatRentTracker.Services
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
