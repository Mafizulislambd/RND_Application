using HomeRentTracker.Models;
using HomeRentTracker.Models.FlatInfoEntity;
using HomeRentTracker.Models.FlatRentEntity;
using HomeRentTracker.Models.OwnerEntity;

namespace HomeRentTracker.Services.Contract
{
    public interface IFlatRentContract
    {
        Task<IEnumerable<FlatRent>> GetAllFlatsAsync();
        Task<List<OwnerInfo>> GetOwnerList();

        Task<FlatRent> GetFlatByIdAsync(int id);
        Task InsertFlatAsync(FlatRent flat);
        Task UpdateFlatAsync(FlatRent flat);
        Task DeleteFlatAsync(int id);
       Task<List<SelectValueList>> GetFlatInfoList(string userId,string owenerId);
    }
}
