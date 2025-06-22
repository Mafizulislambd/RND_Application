using HomeRentTracker.Models.OwnerEntity;
namespace HomeRentTracker.Services.Contract
{
    public interface IOwnerRepository
    {
        Task<List<OwnerInfo>> GetOwnerList();
        Task<List<OwnerInfo>> GetAllOwnersAsync(OwnerFilterViewModel filter);
        Task<OwnerInfo> GetOwnerByIdAsync(int id);
        Task<bool> CreateOwnerAsync(OwnerInfo owner);
        Task<bool> UpdateOwnerAsync(OwnerInfo owner);
        Task<bool> DeleteOwnerAsync(int id);
    }
}
