using HomeRentTracker.Models.RenterEntity;

namespace HomeRentTracker.Services.Contract
{
    public interface IRenterService
    {
        Task<IEnumerable<RenterInfo>> GetAllAsync();
        Task<RenterInfo?> GetByIdAsync(int id);
        Task<int> AddAsync(RenterInfo renter);
        Task UpdateAsync(RenterInfo renter);
        Task DeleteAsync(int id);
    }

}
