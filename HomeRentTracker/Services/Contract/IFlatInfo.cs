using HomeRentTracker.Models.FlatInfo;
using System.Net;

namespace HomeRentTracker.Services.Contract
{
    public interface IFlatInfo
    {
        Task<List<FlatInformation>> GetAllAsync();
        Task<FlatInformation?> GetByIdAsync(int id);
        Task AddAsync(FlatInformation model);
        Task UpdateAsync(FlatInformation model);
        Task DeleteAsync(int id);
    }
}
