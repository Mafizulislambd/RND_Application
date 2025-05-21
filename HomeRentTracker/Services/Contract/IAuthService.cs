using HomeRentTracker.Models.LoginEntity;

namespace HomeRentTracker.Services.Contract
{
    public interface IAuthService
    {
        Task<LoginModel?> LoginAsync(string username, string password);
    }
}
