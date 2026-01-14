using HomeRentTracker.Models.LoginEntity;

namespace HomeRentTracker.Services.Contract
{
    public interface IAuthContract
    {
        Task<LoginViewModel?> LoginAsync(string username, string password);
    }
}
