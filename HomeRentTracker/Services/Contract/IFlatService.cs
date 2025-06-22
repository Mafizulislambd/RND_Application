using HomeRentTracker.Models.FlatEntity;
using HomeRentTracker.Models.OwnerEntity;

namespace HomeRentTracker.Services.Contract
{
    public interface IFlatService
    {
        Task<IEnumerable<Flat>> GetAllFlatsAsync();
        Task<List<OwnerInfo>> GetOwnerList();

        Task<Flat> GetFlatByIdAsync(int id);
        Task InsertFlatAsync(Flat flat);
        Task UpdateFlatAsync(Flat flat);
        Task DeleteFlatAsync(int id);
    }
}
