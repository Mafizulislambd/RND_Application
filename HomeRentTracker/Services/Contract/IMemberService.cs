using HomeRentTracker.Models.RenterEntity;

namespace HomeRentTracker.Services.Contract
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberInfo>> GetAllAsync();
        Task<MemberInfo?> GetByIdAsync(int id);
        Task<int> AddAsync(MemberInfo member, int renterID, string renterNID);
        Task UpdateAsync(MemberInfo member);
        Task DeleteAsync(int id);
    }
}
