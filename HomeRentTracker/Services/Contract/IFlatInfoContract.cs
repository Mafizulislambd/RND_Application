using HomeRentTracker.Models;
using HomeRentTracker.Models.FlatInfoEntity;
using System.Net;

namespace HomeRentTracker.Services.Contract
{
    public interface IFlatInfoContract
    {
        Task<List<FlatInformation>> GetAllAsync();
        Task<FlatInformation?> GetByIdAsync(int id);
        Task AddAsync(FlatInformation model);
        Task UpdateAsync(FlatInformation model);
        Task DeleteAsync(int id);
        Task<List<SelectValueList>> GetFlatInfoList(string userId, string owenerId);

    }
}
