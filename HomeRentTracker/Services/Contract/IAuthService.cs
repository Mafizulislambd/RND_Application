using HomeRentTracker.Models.LoginEntity;

namespace HomeRentTracker.Services.Contract
{
    public interface IAuthService
    {
        Task<LoginViewModel?> LoginAsync(string username, string password);
    }
}
