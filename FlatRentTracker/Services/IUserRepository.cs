using FlatRentTracker.Models;

namespace FlatRentTracker.Services
{
    public interface IUserServices
    {
        Task<UserLoginResult> CheckLoginAsync(UserLoginRequest request);
    }
}
