using HomeRentTracker.Models.RenterEntity;

namespace HomeRentTracker.Services.Contract
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberInfo>> GetAllAsync();
        Task<MemberInfo?> GetByIdAsync(int id);
        Task AddAsync(MemberInfo member);
        Task UpdateAsync(MemberInfo member);
        Task DeleteAsync(int id);
    }
}
